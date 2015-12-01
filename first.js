
function setcookie()
{
	if(document.myform.customer.value=="")
	{
		alert("enter some value");
		return;
	}
	cookievalue=escape(document.myform.customer.value)+";";
	document.cookie="name="+cookievalue;
	document.write("Setting cookie for name="+cookievalue;
}

function getcookie()
{
	var cookienames=document.cookie;
	document.write("allcookies"+cookienames);
	cookiearray=cookienames.split(';');
	for(var i=0;i<cookiearray.length;i++)
	{
		name=cookiearray[i].split('=')[0];
		value=cookiearray[i].split('=')[1];
		document.write("name="+name+"value="+value);
	}
}
