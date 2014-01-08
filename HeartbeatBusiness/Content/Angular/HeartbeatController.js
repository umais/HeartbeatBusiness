HeartbeatApp.controller("HeartbeatController", function AppController($scope, HeartbeatService, $timeout) {
    $scope.Author = HeartbeatService.serviceAuthor.Name;
    $scope.menuItems = [{ name: 'About', cls: 'nav active', url: 'about' }, { name: 'Home', cls: 'nav', url: 'home' }, { name: 'Register', cls: 'nav', url: 'register' }];



    $scope.init = function () {
       
    };

   
    //End of Scope Function
}
);