//define
const app = angular.module('App', ['angularUtils.directives.dirPagination']);
const apiCity = '/Scripts/Data/Datacity.json';

"use strict"
//Call 
app.controller('MenuController', MenuController);

app.controller('ProductController', ProductController);

app.controller('DetailController', DetailController);

app.controller('CartController', CartController);

app.controller('OrderController', OrderController);

app.controller('PaymentController', PaymentController);

app.controller('LoginController', LoginController);

app.controller('RegisterController', RegisterController);

app.controller('SlideController', SlideController);

//Function
function MenuController($rootScope, $scope, $http) {
    $scope.customer = JSON.parse(localStorage.getItem('customer'));

    $scope.SignOut = () => {
        localStorage.removeItem('customer');
        window.location.reload();
    }
}

function SlideController($rootScope, $scope, $http) {
    const urlGetNewArrival = '/Product/GetNewArrival';
    const urlGetHot = '/Product/GetHot';
    const urlGetBestSeller = '/Product/GetBestSeller';
    const urlGetSale = '/Product/GetSale';

    // Set up slider
    function setupSlider() {
        $('.product-carousel').owlCarousel({
            loop: true,
            margin: 20,
            nav: true,
            items: 4,
            navText: ["<a href='javascript:void(0)' class='btn-slide'><i class='ti-angle-left'></i></a>",
                "<a href='javascript:void(0)' class='btn-slide'><i class='ti-angle-right'></i></a>"],
            dots: false
        });
        $('window').resize();
    };

    //setTimeout(setupSlider, 500);

    //numbers of item in slide product
    const rows = 4;

    //Get newarrival
    $http({
        method: 'GET',
        url: urlGetNewArrival,
        params: { rows }
    }
    ).then(res => {
        //setTimeout(setupSlider, 500);
        console.log(res.data);
        $scope.productNewArrival = res.data;

    }, err => {
        console.log(`Message: ${err}`);
    })

    //Get hot
    $http({
        method: 'GET',
        url: urlGetHot,
        params: { rows }
    }
    ).then(res => {
        //setTimeout(setupSlider, 500);
        console.log(res.data);
        $scope.productHot = res.data;
    }, err => {
        console.log(`Message: ${err}`);
    })

    //Get best seller
    $http({
        method: 'GET',
        url: urlGetBestSeller,
        params: { rows }
    }
    ).then(res => {
        //setTimeout(setupSlider, 500);
        console.log(res.data);
        $scope.productBestSeller = res.data;
    }, err => {
        console.log(`Message: ${err}`);
    })

    //Get sale
    $http({
        method: 'GET',
        url: urlGetSale,
        params: { rows }
    }
    ).then(res => {
        console.log(res.data);
        setTimeout(setupSlider, 500);
        $scope.productSale = res.data;
    }, err => {
        console.log(`Message: ${err}`);
    })

    // go to product detail
    $scope.GoToDetail = (product) => localStorage.setItem('product_detail_id', product.product_id)
}

function ProductController($rootScope, $scope, $http) {
    // init sort
    $scope.sortColumn = '';
    $scope.reverse = true;
    $scope.direct = ''; // or Descending

    // handle sort
    $scope.SortBy = () => {
        const value = $scope.valueSort.split('|');
        $scope.sortColumn = value[0];
        $scope.direct = value[1];
        if ($scope.direct === 'Ascending') {
            $scope.reverse = false;
            $scope.direct = 'Descending';
        }
        else {
            $scope.reverse = true;
            $scope.direct = 'Ascending';
        }
    }

    // set up pagination
    $scope.max_size = 3;
    $scope.total_count = 0;
    $scope.page_index = 1;
    $scope.page_size = 6; //number of items per page
    $scope.keyword = '';
    $scope.category_id = '';

    // get categorys
    const urlGetCategoryList = '/Product/GetCategoryList'
   

    $scope.GetCategoryList = () => {
        $http(
            {
                method: 'GET',
                url: urlGetCategoryList,
            }).then((res) => {
                console.log(res.data);
                $scope.listCategorys = res.data;
            }, (err) => {
                console.log(`Message: ${err}`);
            })
    }
    $scope.GetCategoryList();

    // get products 
    const urlGetProductList = '/Product/GetProductList';
    $scope.GetProductList = (index) => {
        const category_id = localStorage.getItem('category_id');
        $scope.category_id = (category_id == null) ? '' : category_id

        $http(
        {
            method: 'GET',
            url: urlGetProductList,
            params: {
                category_id: category_id, page_index: index,
                page_size: $scope.page_size, product_name: $scope.keyword
            }
            }).then((res) => {
                console.log(res.data);
                $scope.ListProduct = res.data;
                $scope.total_count = $scope.ListProduct.total_count;
            },  (err) => {
                console.log(`Message: ${err}`);
        })
    }
    $scope.GetProductList($scope.page_index);


    // save category_id
    $scope.SelectCategory = (category, event) => {
        (event == 1) ? localStorage.setItem('category_id', category.category_id)
            : localStorage.setItem('category_id', '');
        $scope.GetProductList($scope.page_index);
    };


    // go to product detail
    $scope.GoToDetail = (product) => localStorage.setItem('product_detail_id', product.product_id)
}

function DetailController($rootScope, $scope, $http) {
    $scope.index = 0;
    $scope.indexSize = 0; 

    const product_detail_id = localStorage.getItem('product_detail_id');
    const customer = JSON.parse(localStorage.getItem('customer')) ?? null;

    //handle change color, size, image
    angular.element(document).ready(function () {
        const colorItem = $('li.product-detail-color');
        const sizeItem = $('li.product-detail-size');

        colorItem.first().addClass('selectColor');
        sizeItem.first().addClass('selectSize');

        checkQuantity();

        //increase, decrease
        $('.product-amount-plus').click(function () {
            handlingAmount(this, 'plus');
        })

        $('.product-amount-sub').click(function () {
            handlingAmount(this, 'sub');
        })

        //Slider
        let isOnlyImage;
        let slider = runSlider();

        $scope.changeColor = (index, color) => {
            //console.log(index);
            //console.log(color);
            $scope.selectedColor = color.color;

            //refresh thumb slider
            slider.destroy();
            slider = runSlider();

            $scope.index = index;

            $('li.product-detail-color').removeClass('selectColor');
            $(`li:nth-child(${index + 1}).product-detail-color`).addClass('selectColor');

            angular.element(document).ready(function () {
                let hasCurrentSize = $.grep(color.sizes, function (el) {
                    return $scope.currentSize.size === el.size;
                });
                console.log(hasCurrentSize)

                if (hasCurrentSize.length) $(`li:nth-child(${$scope.indexSize + 1}).product-detail-size`).addClass('selectSize');
                else $(`li:nth-child(1).product-detail-size`).addClass('selectSize');
            })
            checkQuantity();
        }

        $scope.changeSize = (index, size) => {
            //console.log(index);
            //console.log(size);
            $scope.selectedSize = size.size;

            $scope.maxQuantity = size.quantity;
            $scope.currentSize = size;
            $scope.indexSize = index;
            $('li.product-detail-size').removeClass('selectSize');
            $(`li:nth-child(${index + 1}).product-detail-size`).addClass('selectSize');
            checkQuantity();
        }

        $scope.addToCart = (product_id, product_name, price, image, status) => {
            //status =>  1:addToCart, 2: buynow

            if (customer) {
                const cart = { cart_id: "", customer_id: customer.customer_id };

                const date = new Date().toJSON().slice(0, 10);
                const urlAddToCart = '/Cart/AddToCart';
                const quantity = $('.product-detail-amount').val() ?? 1;

                const cartDetail = {
                    cart_detail_id: "",
                    cart_id: "",
                    product_id,
                    product_name,
                    image,
                    color: $scope.selectedColor,
                    size: $scope.selectedSize,
                    price,
                    quantity: quantity,
                    date_add: date,
                    status: 1,
                }
                console.log(cartDetail);
                console.log($scope.selectedColor)

                $http({
                    method: 'POST',
                    url: urlAddToCart,
                    data: { cart, cartDetail }
                }).then(res => {
                    //angular.element(document).ready(function () {
                    let cartAmount = Number($('.cart-amount').text());
                    let detailAmount = Number($('.product-detail-amount').val());

                    $('.cart-amount').text(cartAmount + detailAmount);
                    //})
                    //reload carts
                    $rootScope.GetCarts();
                    if (status == 1) {
                        $('.mini-cart-wrap').toggleClass('open');
                        $('.mini-cart .overlay').toggleClass('show');
                    } else {
                        window.open('/Payment/Index', '_self');
                    }
                    console.log(`Status: ${res.status}`);
                }, err => {
                    console.log(`Message: ${err}`);
                })


            } else {
                window.open('/Customer/Login', '_self');
            }
        }
        
    });

    //get selected product
    $http(
        {
            method: 'GET',
            url: '/ProductDetail/GetProductDetail/',
            params: { product_id: product_detail_id }
        }
    ).then((res) => {
        $scope.product = res.data;

        //init 
        const colors = [];
        const listColors = $scope.product.list_color;
        listColors.forEach((item, index) => {
            //init color item
            let colorItem = {
                color: item.color,
                hex: item.hex,
                images: [],
                sizes: []
            }
            // get images    
            //let listImages = (item.images) ? [item.avatar, ...item.images.split(', ')] : [item.avatar, item.avatar];
            let listImages = (item.images) ? [item.avatar, ...item.images.split(', ')] : [item.avatar];

            //show thumb when only one image
            isOnlyImage = (listImages.length === 1) ? true : false;
           

            // get sizes
            let listSizes = [];
            item.list_size.forEach(size => listSizes.push({ size: size.size, quantity: size.quantity }))

            // assign images, sizes
            colorItem.images = listImages;
            colorItem.sizes = listSizes;

            //sort size
            let sizes = ['S', 'M', 'L', 'XL'];
            colorItem.sizes.sort(function (a, b) {
                return sizes.indexOf(a.size) - sizes.indexOf(b.size);
            })

            //push item to colors
            colors.push(colorItem);
        })

        $scope.colors = colors;
        $scope.currentSize = $scope.colors[$scope.index].sizes[$scope.indexSize];
        $scope.maxQuantity = $scope.colors[$scope.index].sizes[$scope.indexSize].quantity;

        $scope.selectedColor = $scope.colors[0].color;
        $scope.selectedSize = $scope.colors[0].sizes[0].size;

        console.log($scope.colors);

    }, (err) => {
        console.log(`Message: ${err}`);
    })

    function checkQuantity() {
        let size, amount;
        $('li.product-detail-size').each((index, el) => {
            if ($(el).hasClass('selectSize')) size = el.innerText;
        })

        if ($scope.colors[$scope.index].sizes != null) {
            $scope.colors[$scope.index].sizes.forEach(el => {
                if (el.size === size) {
                    if (el.quantity > 0) {
                        $('.stock').removeClass('hide');
                        $('.out-of-stock').addClass('hide');
                        $('.limit-stock').addClass('hide');
                    } else {
                        $('.product-detail-amount').val(1);
                        $('.stock').addClass('hide');
                        $('.out-of-stock').removeClass('hide');
                        $('.limit-stock').addClass('hide');
                    }
                }
            })
        }

    }

    //Functions handle
    function handlingAmount(e, sign) {
        let currentAmount = Number($(e).siblings('.product-detail-amount').val());
        if (sign == 'plus') {
            if ($('.out-of-stock').hasClass('hide')) {

                if (currentAmount < $scope.maxQuantity) {
                    currentAmount += 1;
                } else {
                    $('.stock').addClass('hide');
                    $('.out-of-stock').addClass('hide');
                    $('.limit-stock').removeClass('hide');
                }
            }
        } else {
            if (currentAmount > 1) {
                $('.stock').removeClass('hide');
                $('.out-of-stock').addClass('hide');
                $('.limit-stock').addClass('hide');
                currentAmount -= 1;
            }
        }
        $(e).siblings('.product-detail-amount').val(currentAmount);
    }
    //function getUniqueListBy(arr, key) {
    //    return [...new Map(arr.map(item => [item[key], item])).values()]
    //}
}

function CartController($rootScope, $scope, $http, $window) {
    $scope.cartEmpty = true;
    $scope.total = 0;
    $scope.totalItems = 0;

    const cartContent = $('.cart-content');
    const cartAmount = $('.cart-amount');
    const customer = JSON.parse(localStorage.getItem('customer'));
    const urlGetCarts = '/Cart/GetCart';

    let listCart;
    if (customer) {
        $rootScope.GetCarts = () => {
            $http({
                method: 'GET',
                url: urlGetCarts,
                params: { customer_id: customer.customer_id }
            }).then(res => {
                $scope.cart = res.data.cart;
                //console.log(res.data.cart)
                if ($scope.cart) {
                    listCart = $scope.cart.listCartDetail;

                    if ($scope.cart.listCartDetail.length != 0) $scope.cartEmpty = false;
                    $scope.total = calcTotal(listCart);
                    $scope.totalItems = calcTotalItems(listCart);
                }
            });
        }
        $rootScope.GetCarts();

        angular.element(document).ready(function () {
            $('.cart-box, .cart-amount').click(() => {
                $rootScope.GetCarts();
            })
        })
    }

    $scope.continueShopping = () => $window.history.back();

    function calcTotal() {
        let res = 0;
        listCart.forEach(item => {
            res += item.price * item.quantity;
        })
        return res;
    }

    function calcTotalItems() {
        let res = 0;
        listCart.forEach(item => {
            res += item.quantity;
        })
        return res;
    }

    //increase/decreate
    const urlUpdateCart = '/Cart/UpdateQuantity';
    $scope.updateCart = (index, product, event) => {

        if (event == 1) {
            product.quantity += 1
        } else { 
            if (product.quantity > 1)
                product.quantity -= 1;
        }

        $http({
            method: 'POST',
            url: urlUpdateCart,
            data: { cartDetail: product }
        }).then(res => {
            console.log(`Status: ${res.status}`);
        }, err => {
            console.log(`Message: ${err}`);
        });

        $scope.total = calcTotal(listCart);
        $scope.totalItems = calcTotalItems(listCart);

        angular.element(document).ready(function () {
            $('.cart-amount').text($scope.totalItems);
            $scope.totalItems = calcTotalItems(listCart);
        })
    }

    const urlRemoveCartDetail = '/Cart/RemoveCartDetail';
    $scope.removeCartDetail = (product) => {
        $http(
            {
                method: 'POST',
                datatype: 'json',
                url: urlRemoveCartDetail,
                data: { cart_detail_id: product.cart_detail_id }
            }

        ).then((res) => {
            if ($scope.cart) {
                if ($scope.cart.listCartDetail.length == 1)
                    $scope.cartEmpty = true;

                //listCart = $scope.cart.listCartDetail;
                var index = $scope.cart.listCartDetail.indexOf(product);
                $scope.cart.listCartDetail.splice(index, 1);

                //if ($scope.cart.listCartDetail.length != 0) $scope.cartEmpty = false;
            }
            $scope.total = calcTotal(listCart);
            $scope.totalItems = calcTotalItems(listCart);

            angular.element(document).ready(function () {
                $('.cart-amount').text($scope.totalItems);
                $scope.totalItems = calcTotalItems(listCart);
            })
        }, (err) => {
            console.log(`Messge: ${err}`);
        })
    }

    // go to product detail
    $scope.GoToDetail = (product) => localStorage.setItem('product_detail_id', product.product_id)
}

function OrderController($rootScope, $scope, $http) {
    const urlGetOrders = '/Order/GetOrders';
    const customer = JSON.parse(localStorage.getItem('customer'));

    $rootScope.GetOrders = () => {
        $http({
            method: 'GET',
            url: urlGetOrders,
            params: { customer_id: customer.customer_id }
        }).then(res => {
            $scope.orders = res.data.orders;
            console.log($scope.orders)
        });
    }
    $rootScope.GetOrders();
}

function PaymentController($rootScope, $scope, $http, $window) {
    const customer = JSON.parse(localStorage.getItem('customer'));

    $.ajaxSetup({
        async: false
    });

    // Get all city of Viet Nam
    $.getJSON(apiCity, function (data) {
        $scope.listProvinces = data;
    })

    // select address
    $scope.selectAddress = (type) => {
        if (type === 0)
            $scope.listProvinces.forEach(prov => {
                if (prov.Id === $scope.selectedProvince) {
                    $scope.listDistricts = prov.Districts;
                    $scope.listCommunes = [];
                    return;
                }
            })
        else
            $scope.listDistricts.forEach(dist => {
                if (dist.Id === $scope.selectedDistrict) {
                    $scope.listCommunes = dist.Wards;
                    return;
                }
            })
    }

    //purchase
    const urlAddOrder = '/Order/AddOrder';
    const order = {
        order_id: "",
        customer_id: "",
        address: "",
        total: 0,
        date_order: "",
        status: 1
    }

    const urlClearCartDetail = '/Cart/ClearCart';
    $scope.clearCartDetail = (id) => {
        $http(
            {
                method: 'POST',
                datatype: 'json',
                url: urlClearCartDetail,
                data: { cart_id: id }
            }
        ).then((res) => {
            console.log(res.status);
        }, (err) => {
            console.log(`Messge: ${err}`);
        })
    }

    $scope.confirmPurchase = (cart) => {
        const cartId = cart.cart_id;
        const date = new Date().toJSON().slice(0, 10);
        order.customer_id = customer.customer_id;
        order.date_order = date;

        const province = $('#province').find(":selected").text().trim();
        const district = $('#district').find(":selected").text().trim();
        const commune = $('#commune').find(":selected").text().trim();
        const specific_address = $('#specific_address').val().trim();
        order.address = `${specific_address}, ${commune}, ${district}, ${province}`;

        let total = 0;
        const listCarts = cart.listCartDetail;
        const orderDetails = [];
       
        listCarts.forEach(item => {
            let orderDetail = {
                order_detail_id: "",
                order_id: "",
                product_id: "",
                product_name: "",
                image: "",
                color: "",
                size: "",
                quantity: 0,
                price: 0
            }

            orderDetail.product_id = item.product_id;
            orderDetail.product_name = item.product_name;
            orderDetail.image = item.image;
            orderDetail.color = item.color;
            orderDetail.size = item.size;
            orderDetail.quantity = item.quantity;
            orderDetail.price = item.price;

            total += item.quantity * item.price;
            orderDetails.push(orderDetail);
        })

        console.log(orderDetails);
        order.total = total;

        $http({
            method: 'POST',
            url: urlAddOrder,
            data: { order, orderDetails }
        }).then(res => {
            console.log(res.status);
            $scope.clearCartDetail(cartId)

            window.open("/Cart/Index", "_self");
        }, err => console.log(`Message: ${err}`));
    }



}

function LoginController($rootScope, $scope, $http) {
    const urlGetCustomer = '/Customer/GetCustomer';
    $scope.close = "";
    $rootScope.remember = false;

    $scope.login = 0;

    $scope.Login = (username, password) => {
        console.log(username, password);

        $http(
            {
                method: 'GET',
                url: urlGetCustomer,
                params: { username, password }
            }
        ).then((res) => {
            if (res.data.login == "0") console.log("Username or password not correct");
            else {
                console.log("Login success")
                $scope.customer = res.data.customer
                localStorage.setItem('customer', JSON.stringify($scope.customer));
                window.open('/Home/Index', '_self');
            }
        }, (err) => {
            console.log(`Message: ${err}`);
        })
    }
}

function RegisterController($rootScope, $scope, $http) {
    const urlRegister = '/Customer/SignUp'
    $scope.Register = (username, name, phone_number, password) => {
        console.log(username, name, phone_number, password);
        $http(
            {
                method: 'POST',
                url: urlRegister,
                dataType: 'json',
                data: { username, name, phone_number, password }
            }
        ).then(res => {
            console.log('Register success');
            window.open('/Customer/Login', '_self');
        }, err => {
            console.log(`Message: ${err}`)
        })
    }
}

function runSlider() {
    const options = {
        gallery: true,
        item: 1,
        /*keyPress: true,*/
        vertical: true,
        enableDrag: true,
        thumbItem: 3,
        thumbMargin: 10,
        easing: 'linear',

        onSliderLoad: function () {
            $(window).resize();
        }, onAfterSlide: function () {
            $(window).resize();
        }
    }

    if (isOnlyImage) {
        options['autoWidth'] = true;

        angular.element(document).ready(function () {
            $('.lSPager').addClass('hideThumb')
        })

    }
    return $('.vertical-slider').lightSlider(options);
}

