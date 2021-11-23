//const { localstorage } = require("modernizr");

var app = angular.module('app_module',
    ['angularUtils.directives.dirPagination', 'ngFileUpload']
);

app.controller('product_admin_controller', ManageProducts)

function ManageProducts($rootScope, $scope, $http, Upload, $timeout, $document) {
    const urlGetCategoryList = '/ProductAdmin/getCategoryList/';
    const urlGetProductList = '/ProductAdmin/getProductList';
    const urlAddProduct = 'ProductAdmin/addProduct';
    const urlDeleteProduct = 'ProductAdmin/deleteProduct';
    const urlUploadFile = '/Admin/ProductAdmin/Upload';



    // set up pagination
    $rootScope.max_size = 3;
    $rootScope.total_count = 0;
    $rootScope.page_index = 1;
    $rootScope.page_size = 5; //number of items per page
    $rootScope.search_name = '';
    $rootScope.category_id = '';

    // get category id
    var category_id = "";
    $scope.getCategoryId = () => {
        category_id = localStorage.getItem('category_id');
        if (category_id == null) {
            category_id = '00000000-0000-0000-0000-000000000000';
        }
    }
    $scope.getCategoryId();

    // save category_id
    $scope.selectCategory = (category) => {
        localstorage.setItem('category_id', category.category_id);
    }

    // get category
    $scope.getCategoryList = () => {
        $http(
            {
                method: 'GET',
                url: urlGetCategoryList
            }
        ).then(function success(d) {
            $rootScope.list_category = d.data.list_category;
        }, function error() {
            alert("Failed");
        })
    }

    $scope.getCategoryList();

    // get products 
    $scope.getProductList = (index) => {
        $http(
            {
                method: 'GET',
                url: urlGetProductList,
                params: {
                    category_id: category_id, page_index: index,
                    page_size: $rootScope.page_size, product_name: $rootScope.search_name
                }
            }
        ).then(function success(d) {
            $scope.ListProduct = d.data;
            $scope.ListProduct.list_product.forEach(el => {
                var pro = el;
                let categoryName =
                    $rootScope.list_category.filter(lc => lc.category_id == pro.category_id)[0].category_name;
                el["category_name"] = categoryName;
            })
            console.log($scope.ListProduct.list_product)
            $rootScope.total_count = $scope.ListProduct.total_count;
        }, function error() {
            alert('FAILED');
        })
    }
    $scope.getProductList($rootScope.page_index);

    //add product
    $scope.initProduct = {
        product_id: '00000000-0000-0000-0000-000000000000',
        product_code: '',
        product_name: '',
        description: '',
        image_avt: '',
        brand: '',
        made_in: '',
        gender: '1',
        status: '1',
        category_id: ''
    }
    $scope.product = $scope.initProduct;

    $scope.addProduct = () => {
        $scope.product.product_code = generateCodeRandom('PR', $scope.ListProduct.list_product, 'product_code', 4);
        $scope.titleModal = 'Add product';
        $scope.event = 1;
    }

    $scope.updateProduct = (product) => {
        $scope.product = product;
        $scope.titleModal = 'Update product';
        $scope.event = 2;
    }

    //save product
    $scope.saveProduct = () => {
        if ($scope.event == 1) {
            console.log($scope.product);
            //$http(
            //    {
            //        method: 'POST',
            //        url: urlAddProduct,
            //        datatype: 'Json',
            //        data: JSON.stringify($scope.product)
            //    }

            //).then(function success(d) {
            //    console.log('add');
            //    //$scope.ListProduct.list_product.push($scope.product);
            //    //$scope.product = null;
            //}, function error() {
            //    alert('Failed');
            //})
        } else {

        }

        $scope.UploadFile($scope.file, $scope.type);
    }

    //delete product
    $scope.deleteProduct = (product) => {
        $scope.selectedDelete = product
    }

    $scope.confirmDelete = (product) => {
        $http(
            {
                method: 'POST',
                url: urlDeleteProduct,
                datatype: 'Json',
                data: { product_id: $scope.selectedDelete.product_id }
            }

        ).then(function success(d) {
            var index = $scope.ListProduct.list_product.indexOf($scope.selectedDelete);
            $scope.ListProduct.list_product.splice(index, 1);
        }, function error() {
            alert('Failed');
        })
        $('#modal-confirm').modal('hide');
    }

    //Upload image
    $scope.UploadImage = (file, type) => {
        $scope.file = file;
        $scope.type = type;
    }

    $scope.UploadFile = (file, type) => {
        $scope.SelectedFile = file;
        $scope.category_symbol =
            ($scope.product.category_id == '9D878519-BB84-4BA4-B05B-EA1B5DF33A11'.toLowerCase()) ? 'TOP' : 'BOTTOM';

        if ($scope.SelectedFile && $scope.SelectedFile.length) {
            Upload.upload({
                url: urlUploadFile,
                data: {
                    file: $scope.SelectedFile,
                    product_code: $scope.product.product_code,
                    category: $scope.category_symbol
                }
            }).then(d => {
                console.log(d.data);
                if (type == 'image') $scope.product.image_avt = "assets/images/" + d.data[0];
            }, (error) => { alert('Failed')})
        }
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

// Create id random format 
function generateCodeRandom(prefix, listItem, fieldCheck, l) {
    let randomNumber;
    let re = new RegExp(prefix, "gi");

    let end = '9';
    end = this.addZero(end, l, 'after');

    randomNumber = Math.floor(Math.random() * Number(end));
    for (let i = 0; i < listItem.length; i++) {
        if (randomNumber === Number(listItem[i][fieldCheck].replace(re, ''))) {
            randomNumber = Math.floor(Math.random() * Number(end));
        }
    }
    return prefix + randomNumber;
}


function addZero(codeNumber, l, choice) {
    while (codeNumber.length < l) {
        if (choice === 'pre') {
            codeNumber = '0' + codeNumber;
        } else {
            codeNumber = codeNumber + '0';
        }
    }
    return codeNumber;
}