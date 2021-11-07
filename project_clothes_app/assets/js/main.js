$('.hero-search-type > a').click(function() {
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

$('.hero-carousel').owlCarousel({
    loop: true,
    margin: 10,
    nav: true,
    items: 1,
    navText: ["<a href='javascript:void(0)' class='btn-slide'><i class='ti-angle-left'></i></a>",
    "<a href='javascript:void(0)' class='btn-slide'><i class='ti-angle-right'></i></a>"],
    dots: false
})

$('.product-carousel').owlCarousel({
    loop: true,
    margin: 20,
    nav: true,
    items: 4,
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

$('#vertical-slider').lightSlider({
    gallery: true,
    item: 1,
    vertical: true,
    enableDrag: true,
    thumbItem: 3,
    thumbMargin: 10,
    onSliderLoad: function () {
        $(window).resize();
    }, onAfterSlide: function () {
        $(window).resize();
    }

    //slideMargin: 0
});

//$.each($(".lightSlider"), function (i, instance) {
//    $(instance).imagesLoaded(function () {
//        $(instance).lightSlider();
//    });
//});

$(window).click(function(e) {
    if(!$(e.target).is(
    '.hero-search-type > *, .label-search-type-list, .ti-angle-right')) {
        $('.hero-search-type-list').removeClass('active');
    }
})