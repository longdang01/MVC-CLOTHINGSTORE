//const { localstorage } = require("modernizr");

var app = angular.module('AdminApp', ['angularUtils.directives.dirPagination', 'ngFileUpload']);

app.controller('ManageProductsController', ManageProducts)

function ManageProducts($rootScope, $scope, $http, Upload, $timeout, $document) {
    const urlGetCategoryList = '/Admin/ManageProducts/GetCategoryList';
    const urlGetProductList = '/Admin/ManageProducts/GetProductList';
    const urlAddProduct = '/Admin/ManageProducts/AddProduct';
    const urlUpdateProduct = '/Admin/ManageProducts/UpdateProduct';
    const urlRemoveProduct = '/Admin/ManageProducts/RemoveProduct';
    const urlUploadFile = '/Admin/ManageProducts/Upload';

    // set up pagination
    $scope.max_size = 3;
    $scope.total_count = 0;
    $scope.page_index = 1;
    $scope.page_size = 5; //number of items per page
    $scope.search_name = '';
    $scope.category_id = '';

    // get category id
    var category_id = localStorage.getItem('category_id');
    if (category_id == null) category_id = '00000000-0000-0000-0000-000000000000';

    // get category
    $scope.GetCategoryList = () => {
        $http(
            {
                method: 'GET',
                url: urlGetCategoryList
            }
        ).then(function success(d) {
            $scope.list_category = d.data.list_category;
        }, function error() {
            alert("Failed");
        })
    }

    $scope.GetCategoryName = (products) => {
        products.forEach(el => {
            var pro = el;
            let categoryName =
                $scope.list_category.filter(lc => lc.category_id == pro.category_id)[0].category_name;
            el["category_name"] = categoryName;
        })
    }

    $scope.GetCategoryList();

    // get products 
    $scope.GetProductList = (index) => {
        $http(
            {
                method: 'GET',
                url: urlGetProductList,
                params: {
                    category_id: category_id, page_index: index,
                    page_size: $scope.page_size, product_name: $scope.search_name
                }
            }).then((res) => {
                console.log(res.data);
                $scope.ListProduct = res.data;
                $scope.GetCategoryName($scope.ListProduct.list_product);

                $scope.total_count = $scope.ListProduct.total_count;
            }, (err) => {
                console.log(`Message: ${err}`);
            })
    }
    $scope.GetProductList($scope.page_index);

    // save category_id
    $scope.SelectCategory = (category) => localstorage.setItem('category_id', category.category_id);

    // go to product detail
    $scope.GoToDetail = (product) => localStorage.setItem('product_detail_id', product.product_id)

    //Handle product (add, update, remove)
    //add product
    var initProduct = {
        product_id: "00000000-0000-0000-0000-000000000000",
        product_code: "",
        product_name: "",
        description: "",
        brand: "",
        made_in: "",
        gender: "",
        status: "",
        category_id: "00000000-0000-0000-0000-000000000000",
        list_color: [],
        price: {}
    }
   
    $scope.product = initProduct;

    $scope.AddProduct = (event) => {
        $scope.product = initProduct;
        $scope.product.product_code = generateCodeRandom('PR', $scope.ListProduct.list_product, 'product_code', 4);
        $scope.titleModal = 'Add product';
        $scope.event = event;
    }

    $scope.UpdateProduct = (product, event) => {
        $scope.product = product;
        $scope.titleModal = 'Update product';
        $scope.event = event;
    }

    //save product
    $scope.SaveProduct = (product, event) => {
        //handle image
        //if ($scope.product.image_avt.name) {
        //    let prefix = 'assets/images/';
        //    let dotPosition = $scope.product.image_avt.name.indexOf('.');
        //    let extension = $scope.product.image_avt.name.substr(dotPosition);
        //    let fileName = $scope.product.product_code;
        //    let symbol = ($scope.product.category_id == '9D878519-BB84-4BA4-B05B-EA1B5DF33A11'.toLowerCase()) ? 'TOP' : 'BOTTOM';
        //    $scope.product.image_avt = prefix + fileName + '_' + symbol + '_1' + extension;
        //    console.log($scope.event);
        //}
        //execute event
        if (event === 0) {
            console.log(product);
            $http(
                {
                    method: 'POST',
                    dataType: 'json',
                    url: urlAddProduct,
                    data: JSON.stringify(product)
                }
            ).then((res) => {
                console.log('add');
                $scope.ListProduct.list_product = [product, ...$scope.ListProduct.list_product];
                $scope.GetCategoryName($scope.ListProduct.list_product);

                //$scope.product = $scope.initProduct;
            }, (err) => {
                console.log(`Message: ${err}`);
            })
        } else {
            console.log(product);
            $http(
                {
                    method: 'POST',
                    url: urlUpdateProduct,
                    data: { product: product }
                }
            ).then((res) => {
                console.log('updated');
                const index = $scope.ListProduct.list_product
                            .findIndex(i => i.product_id === product.product_id);
                $scope.ListProduct.list_product[index] = product;

                //$scope.ListProduct.list_product.push($scope.product);
                //$scope.product = null;
            }, (err) => {

                console.log(`Message: ${err.message}`);
            })
        }
        //upload file
        //$scope.UploadFile($scope.file, $scope.type);
        $('#modal-handle-product').modal('hide')
    }

    //delete product
    $scope.RemoveProduct = (product) => {
        $scope.selectedDelete = product
    }

    $scope.ConfirmDelete = (product) => {
        $http(
            {
                method: 'POST',
                datatype: 'json',
                url: urlRemoveProduct,
                data: { product_id: $scope.selectedDelete.product_id }
            }

        ).then((res) => {
            var index = $scope.ListProduct.list_product.indexOf($scope.selectedDelete);
            $scope.ListProduct.list_product.splice(index, 1);
        }, (err) => {
            console.log(`Messge: ${err}`);
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
                if (type == 'image') {
                    $scope.product.image_avt = "assets/images/" + d.data[0];
                }
            }, (error) => { alert('Failed')})
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