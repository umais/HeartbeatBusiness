HeartbeatApp.controller("HeartbeatController", function AppController($scope, HeartbeatService, $timeout) {
    $scope.Author = HeartbeatService.serviceAuthor.Name;
    $scope.menuItems = [{ name: 'Home', cls: 'nav active', url: 'home/index' }, { name: 'Timesheet', cls: 'nav', url: 'Home/timesheet' }, { name: 'Register', cls: 'nav', url: 'Home/register' }];
    $scope.Resources = { Invoice: 'Invoice' };
    $scope.startDate = '1/1/2014';
    $scope.endDate = '1/31/2014';
    $scope.timesheet = [];
    //Grid Options
    $scope.GridOptions = {
        data: 'timesheet',
        enableCellSelection: false,
        enableRowSelection: false,
        enableCellEdit: false,
        enableColumnResize: true,
        enableColumnReordering: true,
        columnDefs: [
                     { field: 'ProjectName', displayName: 'Project', enableCellEdit: true, width: 100 },
                     { field: 'TaskName', displayName: 'Task', enableCellEdit: true, width: 100 },
                     { field: 'HoursWorked', displayName: 'Hours Worked', enableCellEdit: true,width:100 },
                     { field: 'WorkDate', displayName: 'Date Worked', enableCellEdit: true, width: 100 },
                     { field: 'ChargeRate', displayName: 'Rate', enableCellEdit: true, width: 100 },
                     { field: 'TotalAmount', displayName: 'Total Amount', enableCellEdit: true, width: 100 },
                     { field: 'Description', displayName: 'Description', enableCellEdit: true, width: 600 }

        ]



    };

    //End Grid Options


    $scope.params = [];
    $scope.init = function () {
        
        $('#startDate').datepicker();
        $('#endDate').datepicker();
    };
    $scope.getReport = function () {
        $scope.startDate = $('#startDate').val();
        $scope.endDate = $('#endDate').val();
        $scope.params.push({ ParamName: 'StartDate', ParamValue: $scope.startDate }, { ParamName: 'EndDate', ParamValue: $scope.endDate });
        HeartbeatService.GetDataByParams($scope.success,$scope.error,$scope.Resources.Invoice,$scope.params)
        $scope.params = [];
    };
    $scope.success = function (response) {
        $scope.timesheet = response;
        $scope.$apply();
    };
    $scope.error = function (result) {
        alert("FAILED : " + result.status + ' ' + result.statusText);
    }
    //End of Scope Function
}
);