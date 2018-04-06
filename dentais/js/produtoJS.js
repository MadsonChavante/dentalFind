
Vue.component('produto' ,{
	props: ['todo'],
  	template: '\
  <div>\
	<div class="col s12 m3 l2"  id="left-produto">\
      <div class="card align center">\
        <div class="card-content">\
          <span class="card-title activator grey-text text-darken-4">{{todo.titulo}}</span>\
        </div>\
      </div>\
    </div>\
    <div class="col s12 m9 l10">\
      <div class="center-align">\
        <div>\
          <img class="responsive-img" id="imgMain" :src=todo.imagem>\
        </div>\
      </div>\
    </div>\
   </div>\
   '
	})

Vue.component('consultas',{
  props: ['todo'],
  template: '\
	<div class="col s12 m12 l12">\
	        <div class="z-depth-2" >\
	              <ul class="collection">\
		              <li class="collection-item avatar">\
			              <i class="material-icons circle">folder</i>\
			              <span class="title">{{ todo.titulo }}</span>\
			              <h4  class="center-align">{{ todo.preco }}</h4>\
			              <h6  class="des center-align">{{todo.descricao}}</h6>\
		              </li>\
	               </ul>\
	        </div>\
	</div>'
  })

var app1 = new Vue({
	el: '#app-1',
	data: {
		produto:[],
		consultaList: [],
	},
	created: function () {
	// GET
	let uri = window.location.search.substring(1); 
    let params = new URLSearchParams(uri);
    let produtoId = params.get("id");
	axios.get("http://localhost:18612/produtos/"+produtoId+"/consultas", )
		.then(SuccessGet)
		.catch(FailureGet);
	}
})

function SuccessGet(dataR) {
	console.log(dataR);
	app1.$data.produto.push({imagem:dataR.data[0].produto.imagem,titulo:dataR.data[0].produto.titulo})	
	for (var i = 0 ; i < dataR.data.length ; i++) {
		if (dataR.data[i].preco !== null) {
			app1.$data.consultaList.push({preco:dataR.data[i].preco,titulo:dataR.data[i].titulo,descricao:dataR.data[i].descricao});
		}
	}
	document.getElementById("progressId").style.display = "none";
}
function FailureGet(data) { console.log('error', data); }
