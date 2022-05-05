// JavaScript Document
$(document).ready(function(){
	$('.yellow-theme').click(function() { 
		$('body').addClass('yellow').removeClass('blue');
	});
	$('.blue-theme').click(function() { 
		$('body').addClass('blue').removeClass('yellow');
	});
});
//wow animation function
wow = new WOW(
  {
	animateClass: 'animated',
	offset:       100,
	callback:     function(box) {
	  console.log("WOW: animating <" + box.tagName.toLowerCase() + ">")
	}
  }
);
wow.init();
    