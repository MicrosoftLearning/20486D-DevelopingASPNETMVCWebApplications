var passingGrade = 55;
$(function() {
    $("#jqueryButton").click(function (event) {
        var firstGrade = parseInt($("#studentGrade1").text());
        var secondGrade = parseInt($("#studentGrade2").text());
        var thirdGrade = parseInt($("#studentGrade3").text());

        if (firstGrade > passingGrade) {
            $("#studentGrade1").addClass("goodGrade");
        }
        else {
            $("#studentGrade1").addClass("badGrade");
        }

        if (secondGrade > passingGrade) {
            $("#studentGrade2").addClass("goodGrade");
        }
        else {
            $("#studentGrade2").addClass("badGrade");
        }

        if (thirdGrade > passingGrade) {
            $("#studentGrade3").addClass("goodGrade");
        } 
        else {
            $("#studentGrade3").addClass("badGrade");
        }
    });
});