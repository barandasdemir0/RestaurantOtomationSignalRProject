using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
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
        private readonly IValidator<CreateBookingDto> _validator;

        public BookingController(IMapper mapper, IBookingService bookingService, IValidator<CreateBookingDto> validator)
        {

            _mapper = mapper;
            _bookingService = bookingService;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var detectedValues = _bookingService.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(detectedValues));
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApprove(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi ");
        }
        [HttpGet("BookingStatusCanceled/{id}")]
        public IActionResult BookingStatusCanceled(int id)
        {
            _bookingService.TBookingStatusCanceled(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi ");
        }










        [HttpPost]
        public IActionResult BookingInsert(CreateBookingDto createBookingDto)
        {
            createBookingDto.BookingDescription = "Rezervasyon Alındı";
            var validationResult = _validator.Validate(createBookingDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
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
