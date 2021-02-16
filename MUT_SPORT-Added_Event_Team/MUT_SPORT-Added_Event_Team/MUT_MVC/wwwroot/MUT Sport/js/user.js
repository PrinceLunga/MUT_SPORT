$(document).ready(function(){
    $("#userProf").on("click",function(){
      $("#dropPop").show();
    });
  

  
    $("#cancelBtn").click(function(){
      $("#dropPop").hide();
    });
  

  
    $("#page-top").click(function(){
      $("#dropPop").hide();
    });
  

  
    $("#alertIcon").click(function(){
      window.location = "Alerts.php";
    });
  
  });