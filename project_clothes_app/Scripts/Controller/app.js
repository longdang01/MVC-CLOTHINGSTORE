const app = angular.module('App', ['angularUtils.directives.dirPagination']);

app.controller('ProductController', ProductController);

app.controller('DetailController', DetailController);

function ProductController($rootScope, $scope, $http) {
    // set up pagination
    $scope.max_size = 3;
    $scope.total_count = 0;
    $scope.page_index = 1;
    $scope.page_size = 6; //number of items per page
    $scope.search_name = '';
    $scope.category_id = '';

    // get category id
    var category_id = localStorage.getItem('category_id');
    if (category_id == null) category_id = '00000000-0000-0000-0000-000000000000';

    // get products 
    const urlGetProductList = '/Shop/GetProductList';
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
                $scope.total_count = $scope.ListProduct.total_count;
            },  (err) => {
                console.log(`Message: ${err}`);
        })
    }
    $scope.GetProductList($scope.page_index);

    // save category_id
    $scope.SelectCategory = (category) => localstorage.setItem('category_id', category.category_id);

    // go to product detail
    $scope.GoToDetail = (product) => localStorage.setItem('product_detail_id', product.product_id)
}

function DetailController($rootScope, $scope, $http) {
    var product_detail_id = localStorage.getItem('product_detail_id');

    $http(
        {
            method: 'GET',
            url: '/ProductDetail/GetProductDetail/',
            params: { product_id: product_detail_id }
        }
    ).then((res) => {
        $scope.product = res.data;
        $scope.index = 0;

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
            let listImages = (item.images) ? [item.avatar, ...item.images.split(', ')] : [item.avatar, item.avatar];

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
        console.log($scope.colors);
    }, (err) => {
        console.log(`Message: ${err}`);
    })

    //function getUniqueListBy(arr, key) {
    //    return [...new Map(arr.map(item => [item[key], item])).values()]
    //}
}

