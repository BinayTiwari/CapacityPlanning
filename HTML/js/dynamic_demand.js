 $(document).ready(function(){
      var i=3;
     $("#add_row").click(function(){
      $('#addr'+i).html("<td>"+ (i+1) +"</td><td>    <select name='name"+i+"' class='form-control input-md'><option>Resource Type</option><option>Technical Consultant</option><option>Business Analyst</option><option>Project Manager</option></select>   </td><td><input  name='mail"+i+"' type='number' placeholder='No of Resources'  class='form-control input-md'></td><td><input  name='mobile"+i+"' type='text' placeholder='Tool/Domain Knowledge '  class='form-control input-md'></td><td><input  name='mobile"+i+"' type='date' placeholder='Start Date'  class='form-control input-md'></td><td><input  name='mobile"+i+"' type='date' placeholder='End Date'  class='form-control input-md'></td>");

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

 //<input name='name"+i+"' type='text' placeholder='Company Name' class='form-control input-md'  />




 //<select name='name"+i+"' class='form-control input-md'><option>Resource Type</option><option>Technical Consultant</option><option>Business Analyst</option><option>Project Manager</option></select>