<template>
  <div class="corpo">
    <Topo />
    <div class="superior">
      <div class="logo">
        <img :src="imagem"/>
      </div>
      <div class="cabecalho">
        <div class="algo">
          {{titulo}}
        </div>
        <div class="i_conteudo">
          <div class="ii">
            Encontramos:
          </div>
          <div class="iii">
            {{itens.length}} produtos relacionados.
          </div>
        </div>
      </div>
      <div>
      </div>
    </div>
    <div class="pesquisar">
      <Pesquisar
			@keydown.enter="get"
      />
    </div>
      <div class="resultados">
        <Card v-for="produto in itens" v-bind:todo="produto" v-bind:key="produto.id"/>
      </div>
  </div>
</template>

<script>

import Topo from '@/components/Topo'
import Pesquisar from '@/components/Pesquisar'
import Card from '@/components/Card_produto'

export default {
  components:{Topo,Pesquisar,Card},
  data(){
    return{
      algo: this.$route.params.algo,
      itens:[],
      imagem:'',
      titulo:''
    }
  },
  created: function (){
    this.get();
  },
  updated: function (){
    //this.get();
  },
  methods:{
    get: function (){
    this.itens = []
    this.axios.get("http://localhost:18612/categorias/"+this.$route.params.id+"/produtos")
      .then(this.SuccessGet)
      .catch(console.log(""));
    },
    SuccessGet: function (dataR) {
      console.log(dataR)
      this.imagem = dataR.data[0].categoria.imagem
      this.titulo = dataR.data[0].categoria.titulo
      for (var i = 0; i < dataR.data.length; i++) {
        this.itens.push({
          titulo: dataR.data[i].titulo,
          imagem: dataR.data[i].imagem,
          economia: dataR.data[i].economia,
          id: dataR.data[i].id,
          consultaId: dataR.data[i].melhorConsulta
        })
      }
    }
  }
}
</script>

<style scoped>
.corpo{
  width: 100%;
  height: 100%;
  position: fixed;
  background-color: #e2e2e2;
}
.pesquisar{
  margin-top: -40px;
  width: 100%;
  display: flex;
  justify-content: center;
  position: fixed;
}
.superior{
  display: flex;
  justify-content: space-between;
  align-items: center;
  height: 200px;
  width: 100%;
}
.logo{
  width: 80px;
  height: 80px;
  margin-left: 20px;
  border-radius: 50px;
  background-color: #ffffff;
}
.cabecalho{
  margin-left: -80px;
  display: flex;
  justify-content: center;
  align-items: center;
}
.cabecalho>div{
  margin: 10px;
}
.algo{
  background-color: #ffffff;
  height: 43px;
  border-radius: 10px;
  font-weight:bold;
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
  padding: 5px;
  display: flex;
  padding: 10px;
  align-items: center;
}
.i_conteudo{
  background-color: #24b1bb;
  height: 43px;
  border-radius: 10px;
  font-weight:bold;
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
  padding: 10px;
  display: flex;
  align-items: center;
}
.ii{
  color: white;
}
.iii{
  margin-left: 10px;
  color: chartreuse;
}
.resultados{
  width: 100%;
  height: 60%;
  background-color: #ffffff;
  display: flex;
  justify-content: center;
  align-items: flex-start;
  margin-top: 35px;
  overflow-y: scroll;
  flex-wrap: wrap;
}
/*tablet*/
@media screen and (max-width: 768px) {
  .cabecalho{
    font-size: 11px;
    margin-top: 0px;
    margin-left: -10px;
  }
  .cabecalho>div{
    height: 20px;
  }
  .logo{
    width: 60px;
    height: 60px;
    margin-left: 20px;
  }
}
/*celular*/
@media screen and (max-width: 425px) {
  .superior{
    flex-direction: column;
    align-items: center;
  }
}
</style>
