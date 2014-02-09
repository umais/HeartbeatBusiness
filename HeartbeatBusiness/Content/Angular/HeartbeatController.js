HeartbeatApp.controller("HeartbeatController", function AppController($scope, HeartbeatService, $timeout) {
    $scope.Author = HeartbeatService.serviceAuthor.Name;
    $scope.menuItems = [{ name: 'Home', cls: 'nav active', url: 'home/index' }, { name: 'Timesheet', cls: 'nav', url: 'Home/timesheet' }, { name: 'Register', cls: 'nav', url: 'Home/register' }];
    $scope.Resources = { Invoice: 'Invoice' ,Workers:'Workers',Tasks:'Tasks'};
    $scope.startDate = '1/1/2014';
    $scope.endDate = '1/31/2014';
    $scope.timesheet = [];
    $scope.workers = [{ ParamName: 'Umais', ParamValue: "1" }]
    $scope.tasks = [];
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
                     { field: 'HoursWorked', displayName: 'Hours Worked', enableCellEdit: true,width:150 },
                     { field: 'WorkDate', displayName: 'Date Worked', enableCellEdit: true, width: 150 },
                     { field: 'ChargeRate', displayName: 'Rate', enableCellEdit: true, width: 100 },
                     { field: 'TotalAmount', displayName: 'Total Amount', enableCellEdit: true, width: 150 },
                     { field: 'Description', displayName: 'Description', enableCellEdit: true, width: 400, cellTemplate: "<div class='AddButton' ng-click='CallUpdateService(row.rowIndex);' ><span class='glyphicon glyphicon-th' data-toggle='tooltip'  data-html='true' title='{{row.entity[col.field]}}'></span></div>" }

        ]



    };

    //End Grid Options


    $scope.params = [];
    $scope.init = function () {
        $scope.getDropDownData();
      
    };
    $scope.getReport = function () {
        $scope.params = [];
        $scope.startDate = $('#startDate').val();
        $scope.endDate = $('#endDate').val();
        $scope.params.push({ ParamName: 'StartDate', ParamValue: $scope.startDate }, { ParamName: 'EndDate', ParamValue: $scope.endDate });
        HeartbeatService.GetDataByParams($scope.success,$scope.error,$scope.Resources.Invoice,$scope.params)
        $scope.params = [];
    };

    $scope.getWorkers = function () {
       
        
        HeartbeatService.GetData($scope.WorkerGetSuccess, $scope.error, $scope.Resources.Workers)
       
    };
    $scope.getTasks = function () {


        HeartbeatService.GetData($scope.TasksGetSuccess, $scope.error, $scope.Resources.Tasks)

    };
    $scope.WorkerGetSuccess = function (response) {
        $scope.workers = response;
        $scope.$apply();
    };

    $scope.TasksGetSuccess = function (response) {
        $scope.tasks = response;
        $scope.$apply();
    }
    $scope.success = function (response) {
        $scope.timesheet = response;
        $scope.$apply();
    };
    $scope.error = function (result) {
        alert("FAILED : " + result.status + ' ' + result.statusText);
    }

    $scope.getDropDownData=function(){
        $scope.getWorkers();
        $scope.getTasks();
    }
    //End of Scope Function
}
);