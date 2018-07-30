 $(document).ready(function(){
      var i=3;
     $("#add_row").click(function(){
      $('#addr'+i).html("<td>"+ (i+1) +"</td><td><input name='name"+i+"' type='text' placeholder='Company Name' class='form-control input-md'  /> </td><td><input  name='mail"+i+"' type='text' placeholder='Designation'  class='form-control input-md'></td><td><input  name='mobile"+i+"' type='date' placeholder='From'  class='form-control input-md'></td><td><input  name='mobile"+i+"' type='date' placeholder='To'  class='form-control input-md'></td>");

      $('#tab_logic').append('<tr id="addr'+(i+1)+'"></tr>');
      i++; 
  });
     $("#delete_row").click(function(){
    	 if(i>1){
		 $("#addr"+(i-1)).html('');
		 i--;
		 }
	 });

});