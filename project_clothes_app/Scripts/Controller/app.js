var app = angular.module('app_module', ['angularUtils.directives.dirPagination']);

app.controller('product_controller', getProductList);

app.controller('product_detail_controller', getProductDetail)

function getProductList($rootScope, $scope, $http) {
    // set up pagination
    $rootScope.max_size = 3;
    $rootScope.total_count = 0;
    $rootScope.page_index = 1;
    $rootScope.page_size = 6; //number of items per page
    $rootScope.search_name = '';
    $rootScope.category_id = '';

    // get category id
    var category_id = "";
    $scope.getCategoryId = function () {
        category_id = localStorage.getItem('category_id');
        if (category_id == null) {
            category_id = '00000000-0000-0000-0000-000000000000';
        }
    }
    $scope.getCategoryId();

    // get products 
    $scope.getProductList = function (index) {
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
            //console.log($scope.ListProduct);    
            $rootScope.total_count = $scope.ListProduct.total_count;
        }, function error() {
            alert('FAILED');
        })
    }
    $scope.getProductList($rootScope.page_index);

    // save category_id
    $scope.selectCategory = function (category) {
        localstorage.setItem('category_id', category.category_id);
    }

    // view product detail
    $scope.ViewDetail = (product) => {
        if (product == null) {
            localStorage.setItem('product_view_detail', '')
        } else {
            localStorage.setItem('product_view_detail', product.product_id)
        }
    }
}

function getProductDetail($rootScope, $scope, $http) {
    var product_view_detail = localStorage.getItem('product_view_detail');

    $http(
        {
            method: 'GET',
            url: '/ProductDetail/getProductDetail/',
            params: { product_id: product_view_detail }
        }
    ).then(function success(d) {
        $scope.Product = d.data;

        const colors = [];
        var sizes = [];
        $scope.Product.list_color.forEach((item, index) => {
            //init colors
            colors.push({ color: item.color, hex: item.hex, images: [], sizes: [] });

            //get list image
            item.list_image.forEach(image => {
                colors[index].images.unshift(image.image);
            })

            colors[index].images.unshift(item.image);

            //get size
            item.list_size.forEach(size => {
                colors[index].sizes.push({ size: size.size, quantity: size.quantity });

                sizes.push({ size: size.size })
            })

            //get all sizes
            sizes = getUniqueListBy(sizes, 'size');

            //sort size
            colors[index].sizes.sort(compare);
            sizes.sort(compare);
        })

        console.log(colors);

        var images = [];
        colors.forEach(item => {
            let el = item.images.join(', ');
            if (item.images.length > 0) {
                item.images.forEach(e => images.push(e));
            }else 
                images.push(el);
            //console.log(item.images.join());
        })
        console.log(images);

        $scope.images = images;
        $scope.colors = { list_color: colors };
        $scope.sizes = sizes;
    }, function error() {
        alert('Failed')
    })

    function getUniqueListBy(arr, key) {
        return [...new Map(arr.map(item => [item[key], item])).values()]
    }

    function compare(a, b) {
        if (a.size < b.size) {
            return -1;
        }
        if (a.size > b.size) {
            return 1;
        }
        return 0;
    }
}
