/// <reference path="angular.min.js" />

//const { localstorage } = require("modernizr");

var app = angular.module('app_module', ['angularUtils.directives.dirPagination']);

app.controller('product_controller', function ($rootScope, $scope, $http) {

    $rootScope.max_size = 3;
    $rootScope.total_count= 0;
    $rootScope.page_index = 1;
    $rootScope.page_size = 5; //number of items per page
    $rootScope.search_name = '';
    $rootScope.category_id = '';

    var category_id = "";
    $scope.getCategoryId = function () {
        category_id = localStorage.getItem('category_id');
        if (category_id == null) {
            category_id = '00000000-0000-0000-0000-000000000000';
        }
    }
    $scope.getCategoryId();
    if (category_id) {
        $scope.getProductList = function (index) {
            const urlPage = '/Shop/getProductList';
            $http(
                {
                    method: 'GET',
                    url: '/Shop/getProductList',
                    params: {
                        category_id: category_id, page_index: index,
                        page_size: $rootScope.page_size, product_name: $rootScope.search_name
                    }
                }
            ).then(function success(d) {
                $scope.ListProduct = d.data;
                $rootScope.total_count = $scope.ListProduct.total_count;
            }, function error() {
                alert('FAILED');
            })
        }
        $scope.getProductList($rootScope.page_index);
    } else {
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
    }

    

    $scope.selectCategory = function (category) {
        localstorage.setItem('category_id', category.category_id);
    }

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