using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BusinessLayer.Abstract;
using Project.DtoLayer.BookingDto;
using Project.DtoLayer.CategoryDto;
using Project.EntityLayer.Concrete;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IMapper mapper, IBookingService bookingService)
        {

            _mapper = mapper;
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList() 
        {
            var detectedValues = _bookingService.TGetListAll();
            return Ok (_mapper.Map<List<ResultBookingDto>>(detectedValues));
        }

        [HttpPost]
        public IActionResult BookingInsert(CreateBookingDto createBookingDto)
        {
            //createBookingDto.BookingDate = DateTime.Now;
            var detectedValues = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TInsert(detectedValues);
            return Ok("Rezervasyon Başarıyla eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult BookingDelete(int id)
        {
            var detectedValues = _bookingService.TGetByID(id);
            _bookingService.TDelete(detectedValues!);
            return Ok("Rezervasyon Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult BookingUpdate(UpdateBookingDto updateBookingDto)
        {
            var detectedValues = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(detectedValues);
            return Ok("Rezervasyon Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult BookingGetByID(int id)
        {
            var detectedValues = _bookingService.TGetByID(id);
            return Ok(detectedValues);
        }
    }
}
