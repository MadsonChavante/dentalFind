
Vue.component('todo-item', {
  props: ['todo'],
  template: '\
  <li class="collection-item avatar">\
	<div>\
		<img class="img-cat" :src="todo.imagem" >\
	</div>\
	<div class="valign-wrapper">\
  		<span class="title">{{ todo.titulo }}</span>\
  	</div>\
  	</li>'
  })
var app7 = new Vue({
	el: '#app-7',
	data: {
		categoriaList: []
	},
	created: function () {
	// GET
	axios.get("http://localhost:18612/categorias", )
		.then(SuccessGet)
		.catch(FailureGet);
	}
})

function imagemDaCategoria(img){
	document.getElementById("").src = img; 
}

function SuccessGet(dataR) {
	console.log(dataR);
	for (var i = 0 ; i < dataR.data.length ; i++) { 
		
		app7.$data.categoriaList.push({titulo:dataR.data[i].titulo, imagem:dataR.data[i].imagem});
	}
	document.getElementById("progressId").style.display = "none";
}
function FailureGet(data) { console.log('error', data); }
