// jQuery Mask Plugin v1.4.0
// github.com/igorescobar/jQuery-Mask-Plugin
(function(h){var w=function(a,g,e){var k=this;a=h(a);var n;g="function"===typeof g?g(a.val(),void 0,a,e):g;k.init=function(){e=e||{};k.byPassKeys=[8,9,16,36,37,38,39,40,46,91];k.translation={0:{pattern:/\d/},9:{pattern:/\d/,optional:!0},"#":{pattern:/\d/,recursive:!0},A:{pattern:/[a-zA-Z0-9]/},S:{pattern:/[a-zA-Z]/}};k.translation=h.extend({},k.translation,e.translation);k=h.extend(!0,{},k,e);a.each(function(){!1!==e.maxlength&&a.attr("maxlength",g.length);a.attr("autocomplete","off");f.destroyEvents();
f.events();f.val(f.getMasked())})};var f={getCaret:function(){var c;c=0;var b=a.get(0);if(document.selection&&-1==navigator.appVersion.indexOf("MSIE 10"))b.focus(),c=document.selection.createRange(),c.moveStart("character",-b.value.length),c=c.text.length;else if(b.selectionStart||"0"==b.selectionStart)c=b.selectionStart;return c},setCaret:function(c){var b;b=a.get(0);b.setSelectionRange?(b.focus(),b.setSelectionRange(c,c)):b.createTextRange&&(b=b.createTextRange(),b.collapse(!0),b.moveEnd("character",
c),b.moveStart("character",c),b.select())},events:function(){a.on("keydown.mask",function(){n=f.val()});a.on("keyup.mask",f.behaviour);a.on("paste.mask",function(){setTimeout(function(){a.keydown().keyup()},100)})},destroyEvents:function(){a.off("keydown.mask").off("keyup.mask").off("paste.mask")},val:function(c){var b="input"===a.get(0).tagName.toLowerCase();return 0<arguments.length?b?a.val(c):a.text(c):b?a.val():a.text()},behaviour:function(c){c=c||window.event;if(-1===h.inArray(c.keyCode||c.which,
k.byPassKeys)){var b,a=f.getCaret();a<f.val().length&&(b=!0);f.val(f.getMasked());b&&f.setCaret(a);return f.callbacks(c)}},getMasked:function(){var a=[],b=f.val(),d=0,h=g.length,l=0,n=b.length,m=1,s="push",p=-1,q,t;e.reverse?(s="unshift",m=-1,q=0,d=h-1,l=n-1,t=function(){return-1<d&&-1<l}):(q=h-1,t=function(){return d<h&&l<n});for(;t();){var u=g.charAt(d),v=b.charAt(l),r=k.translation[u];r?(v.match(r.pattern)?(a[s](v),r.recursive&&(-1===p?p=d:d===q&&(d=p-m),q===p&&(d-=m)),d+=m):r.optional&&(d+=m,
l-=m),l+=m):(a[s](u),v===u&&(l+=m),d+=m)}return a.join("")},callbacks:function(c){var b=f.val(),d=f.val()!==n;if(!0===d&&"function"===typeof e.onChange)e.onChange(b,c,a,e);if(!0===d&&"function"===typeof e.onKeyPress)e.onKeyPress(b,c,a,e);if("function"===typeof e.onComplete&&b.length===g.length)e.onComplete(b,c,a,e)}};k.remove=function(){f.destroyEvents();f.val(k.getCleanVal()).removeAttr("maxlength")};k.getCleanVal=function(){for(var a=[],b=f.val(),d=0,e=g.length;d<e;d++)k.translation[g.charAt(d)]&&
a.push(b.charAt(d));return a.join("")};k.init()};h.fn.mask=function(a,g){return this.each(function(){h(this).data("mask",new w(this,a,g))})};h.fn.unmask=function(){return this.each(function(){try{h(this).data("mask").remove()}catch(a){}})};h("input[data-mask]").each(function(){var a=h(this),g={};"true"===a.attr("data-mask-reverse")&&(g.reverse=!0);"false"===a.attr("data-mask-maxlength")&&(g.maxlength=!1);a.mask(a.attr("data-mask"),g)})})(window.jQuery||window.Zepto);