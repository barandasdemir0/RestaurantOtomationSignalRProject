using Microsoft.AspNetCore.SignalR;
using Project.BusinessLayer.Abstract;
using Project.DataAccessLayer.Concrete;

namespace Project.Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMenuTablesService _menuTablesService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMenuTablesService menuTablesService, IMoneyCaseService moneyCaseService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _menuTablesService = menuTablesService;
            _moneyCaseService = moneyCaseService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendStatistic()
        {
            var values = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", values);

            var values2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", values2);

            var values3 = _categoryService.TCategoryActiveCount();
            await Clients.All.SendAsync("ActiveCategoryCount", values3);

            var values4 = _categoryService.TCategoryPassiveCount();
            await Clients.All.SendAsync("PassiveCategoryCount", values4);

            var values5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("optionHamburgerCount", values5);

            var values6 = _productService.TProductCountByCategoryNamePizza();
            await Clients.All.SendAsync("optionPizzaCount", values6);

            var values7 = _productService.TProductPriceAverage();
            await Clients.All.SendAsync("avgPrice", values7.ToString("0.00₺"));

            var values8 = _productService.TProductPriceByMax();
            await Clients.All.SendAsync("TProductPriceByMax", values8);

            var values9 = _productService.TProductPriceByMin();
            await Clients.All.SendAsync("TProductPriceByMin", values9);

            var values10 = _productService.TProductPriceByHamburger();
            await Clients.All.SendAsync("TProductPriceByHamburger", values10.ToString("0.00₺"));

            var values11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("TTotalOrderCount", values11);

            var values12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("TActiveOrderCount", values12);


            var values13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("TLastOrderPrice", values13);


            var values14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("TTotalMoneyCaseAmount", values14.ToString("0.00₺"));


            var values15 = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("TTodayTotalPrice", values15.ToString("0.00₺"));


            var values16 = _menuTablesService.TMenuTableCount();
            await Clients.All.SendAsync("TMenuTableCount", values16);



        }

        public async Task SendProgress()
        {

            var values = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("TTotalMoneyCaseAmount", values.ToString("0.00₺"));

            var values2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("TActiveOrderCount", values2);

            var values3 = _menuTablesService.TMenuTableCount();
            await Clients.All.SendAsync("TMenuTableCount", values3);


        }
        

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);

        }

        public async Task SendNotification()
        {
            var values = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationList", values);
            var values2 = _notificationService.TGetAllNotificationsByFalse();
            await Clients.All.SendAsync("ReceiveNotificationAllListFalse", values2);
        }

    }
}
//hub burada sunucu görevi görür dağitim işlemi buradan olacak