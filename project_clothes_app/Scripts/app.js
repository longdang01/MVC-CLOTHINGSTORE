/// <reference path="angular.min.js" />

var app = angular.module('app_module', []);

app.controller('product_controller', function ($rootScope, $scope, $http) {
    $http(
        {
            method: 'GET',
            url: '/Shop/getProducts'
        }
    ).then(function success(d) {
        $scope.Products = d.data.products;
    }, function error() {
        alert('FAILED')
    })

    $scope.ViewDetail = (product) => {
        if (product == null) {
            localStorage.setItem('product_view_detail', '')
        } else {
            localStorage.setItem('product_view_detail', product.product_id)
        }
    }
})

app.controller('product_detail_controller', function ($rootScope, $scope, $http) {
    var product_view_detail = localStorage.getItem('product_view_detail');

    $http(
        {
            method: 'GET',
            url: '/ProductDetail/getProductDetail/',
            params: { product_id: product_view_detail }
        }
    ).then(function success(d) {
        $scope.Product = d.data;
    }, function error() {
        alert('FAILED')
    })
})