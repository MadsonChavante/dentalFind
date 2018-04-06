
Vue.component('adicionar-produto', {
  props: ['todo'],
  template: '\
  	<div class="adicionarProduto">\
		<div class="input-field col s12 m6 l3">\
  			<input id="titulo" type="text" class="validate">\
  			<label for="titulo">Titulo</label>\
		</div>\
		<div class="input-field col s12 m2 l2">\
  			<input id="categoriaId" type="number" class="validate">\
  			<label for="categoriaId">Id categoria</label>\
		</div>\
		<div class="input-field col s12 m4 l6">\
  			<input id="imagem" type="text" class="validate">\
  			<label for="imagem">Imagem</label>\
		</div>\
		<span  id="saida1"></span>\
	</div>'
})
Vue.component('adicionar-consulta', {
  props: ['todo'],
  template: '\
  	<div class="adicionarConsulta">\
		<div class="input-field col s12 m6 l3">\
  			<input id="tituloc" type="text" class="validate">\
  			<label for="titulo">Titulo</label>\
		</div>\
		<div class="input-field col s12 m2 l2">\
  			<input id="produtoId" type="number" class="validate">\
  			<label for="produtoId">Id produto</label>\
		</div>\
		<div class="input-field col s12 m4 l6">\
  			<input id="site" type="text" class="validate">\
  			<label for="site">Site</label>\
		</div>\
		<div class="input-field col s12 m12 l12">\
  			<input id="caminho" type="text" class="validate">\
  			<label for="caminho">Caminho</label>\
		</div>\
		<div class="input-field col s12 m12 l12">\
  			<input id="descricao" type="text" class="validate">\
  			<label for="descricao">Descrição</label>\
		</div>\
		<span  id="saida2"></span>\
	</div>'
})

var crud = new Vue({
	el: '#crud',
	data: {}
})
function adicionarProduto(titulop,categoriaIdp,imagemp) {
	if (titulop !== "" && categoriaIdp !== "" && imagemp !== "") {
		
		let data = JSON.stringify({
	        id: 0,
	        titulo: titulop,
	        imagem: imagemp,
	        categoriaId: categoriaIdp
	    })

	 	axios.post('http://localhost:18612/produto', data ,{
	 		headers: {
	 		'Accept': 'application/json',
            'Content-Type': 'application/json;charset=utf-8',
        	}
	 	})
        	.then(function (res) {
	        	console.log("adicionado com sucesso");
	        	console.log(res.data.id);
	        	document.getElementById('saida1').innerHTML = 'id = '+res.data.id; 
	        })
	        .catch(function (err) {
	        	console.log("erro")
	        });
		
		//data = JSON.parse(data);
		console.log(data);
	}
	else{
		console.log("campo invalido");
	}
}
function adicionarConsulta(titulop,produtoIdp,sitep,caminhop,descricaop) {
	if (titulop !== "" && produtoIdp !== "" && sitep !== "" && caminhop !== "" && descricaop !== "") {
		
		let data = JSON.stringify({
	        id: 0,
	        titulo: titulop,
	        produtoId: produtoIdp,
	        site: sitep,
	        caminho: caminhop,
	        descricao: descricaop
	    })

	 	axios.post('http://localhost:18612/consulta', data ,{
	 		headers: {
	 		'Accept': 'application/json',
            'Content-Type': 'application/json;charset=utf-8',
        	}
	 	})
        	.then(function (res) {
	        	console.log("adicionado com sucesso");
	        	console.log(res.data.id);
	        	document.getElementById('saida2').innerHTML = 'id = '+res.data.id; 
	        })
	        .catch(function (err) {
	        	console.log("erro")
	        });
		
		//data = JSON.parse(data);
		console.log(data);
	}
	else{
		console.log("campo invalido");
	}
}
