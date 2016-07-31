namespace TimeManagment {

    angular.module('TimeManagment', ['ui.router', 'ngResource', 'ui.bootstrap', 'angular.filter']).config((  //added angular.filter 
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: TimeManagment.Controllers.HomeController,
                controllerAs: 'controller'
            })

            //start here for new starts 07/07/2016
            .state('toDoList', {
                url: '/toDoList',
                templateUrl: '/ngApp/views/toDoList.html',
                controller: TimeManagment.Controllers.ToDoListController,
                controllerAs: 'controller'
            })
          
            .state('contact', {
                url: '/contact',
                templateUrl: '/ngApp/views/contact.html',
                controller: TimeManagment.Controllers.ContactController,
                controllerAs: 'controller'
            })

            //end of edit

            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: TimeManagment.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: TimeManagment.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: TimeManagment.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: TimeManagment.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: TimeManagment.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            })

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });



  



    angular.module('TimeManagment').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('TimeManagment').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
