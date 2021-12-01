const app = angular.module('App', ['angularUtils.directives.dirPagination']);

//Call 
app.controller('MenuController', MenuController);

app.controller('ProductController', ProductController);

app.controller('DetailController', DetailController);

app.controller('LoginController', LoginController);

app.controller('RegisterController', RegisterController);

//Function
function MenuController($rootScope, $scope, $http) {
    $scope.customer = JSON.parse(localStorage.getItem('customer'));

    $scope.SignOut = () => {
        localStorage.removeItem('customer');
        window.location.reload();
    }
}

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
    if (category_id == null) category_id = '';

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