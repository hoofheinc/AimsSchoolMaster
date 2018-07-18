$(document).ready(function () {
    $('#myStudentGrid').DataTable({
		"ajax": {
			"url": "../Portal/GetStudentList/",
			"type": "GET",
			"datatype": "json",
            "dataSrc": ""
        },        
		"columns": [
			{ "data": "FullName" },
			{ "data": "Email" },
            {
                sortable: false,
                "render": function (data, type, full, meta) {
                    var buttonID = "rollover_" + full.id;
                    //alert(full.FullName);
                    
                    return '<a href= "/Portal/ViewStudent/?Id=' + full.UserID + '" id=' + buttonID + ' class="btn btn -default" role="button">View Details</a>';
                }
            }
		]
	});
}); 
$(document).ready(function () {
    $('#myTeacherGrid').DataTable({
        "ajax": {
            "url": "../Portal/GetTeacherList/",
            "type": "GET",
            "datatype": "json",
            "dataSrc": ""
        },
        "columns": [
            { "data": "FullName" },
            { "data": "Email" }
        ]
    });
});