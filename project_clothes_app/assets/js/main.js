//Run
$('.close-mini-cart, .mini-cart .overlay').click(() => {
    $('.mini-cart-wrap').removeClass('open');
    $('.mini-cart .overlay').removeClass('show');
})

$('.cart-box, .cart-amount').click(() => {
    $('.mini-cart-wrap').toggleClass('open');
    $('.mini-cart .overlay').toggleClass('show');
})

$('.hero-search-type > a').click(function () {
    $(this).siblings().find('a').each(function() {
        if($('.label-search-type-list').text() === $(this).text()) {
            $(this).addClass('activated');
        }else {
            $(this).removeClass('activated');
        } 
    })
    $(this).siblings().toggleClass('active');
})

$('.hero-search-type-list a').click(function() {
    $('.label-search-type-list').text($(this).text());
    $('.hero-search-type-list').removeClass('active');
})


//Carousel
$('.hero-carousel').owlCarousel({
    loop: true,
    margin: 10,
    nav: true,
    items: 1,
    navText: ["<a href='javascript:void(0)' class='btn-slide'><i class='ti-angle-left'></i></a>",
    "<a href='javascript:void(0)' class='btn-slide'><i class='ti-angle-right'></i></a>"],
    dots: false
})



$('.journal-carousel').owlCarousel({
    loop: true,
    margin: 20,
    nav: true,
    items: 3,
    navText: ["<a href='javascript:void(0)' class='btn-slide'><i class='ti-angle-left'></i></a>",
    "<a href='javascript:void(0)' class='btn-slide'><i class='ti-angle-right'></i></a>"],
    dots: false
})



//const colorItem = $('li.product-detail-color');
//const sizeItem = $('li.product-detail-size');
//colorItem.first().addClass('selectColor');
//sizeItem.first().addClass('selectSize');

//console.log($('li:nth-child(1).product-detail-color'));

//$('li:nth-child(1).product-detail-color').addClass('selectColor');
//$('li:nth-child(1).product-detail-size').addClass('selectSize');



//$('#vertical-slider').lightSlider({
//    gallery: true,
//    item: 1,
//    keyPress: true,
//    vertical: true,
//    enableDrag: true,
//    thumbItem: 3,
//    thumbMargin: 10,
//    easing: 'linear',

//    onSliderLoad: function () {
//        $(window).resize();
//    }, onAfterSlide: function () {
//        $(window).resize();
//    }
//});

$(window).click(function(e) {
    if(!$(e.target).is(
    '.hero-search-type > *, .label-search-type-list, .ti-angle-right')) {
        $('.hero-search-type-list').removeClass('active');
    }

    if (e.target.classList.contains('modal')) {
        $('.modal').css('display', 'none');
    }
})


//// Modal
//$('.btn-user-login').click(function () {
//    $('.modal-login').css('display', 'grid');
//})

//$('.btn-close-modal').click(function () {
//    $('.modal').css('display', 'none');
//})

//$('.btn-back').click(function () {
//    $('.modal').css('display', 'none');
//})

