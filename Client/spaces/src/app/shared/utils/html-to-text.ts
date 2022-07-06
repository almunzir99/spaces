export const HTMLToText = (html:string) : string => {
   var div = document.createElement('div');
   div.innerHTML = html;
   return div.textContent || div.innerText || "";
};