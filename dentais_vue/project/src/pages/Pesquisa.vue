<template>
  <div class="corpo">
    <Topo />
    <div class="cabecalho">
      <div class="algo">
        {{algo}}
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
      itens:[]
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
    this.axios.get("http://localhost:18612/pesquisar/"+this.$route.params.algo)
      .then(this.SuccessGet)
      .catch(console.log(""));
    },
    SuccessGet: function (dataR) {
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
.cabecalho{
  height: 200px;
  width: 100%;
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
    margin-top: -40px;
  }
}
/*celular*/
@media screen and (max-width: 425px) {
}
</style>
