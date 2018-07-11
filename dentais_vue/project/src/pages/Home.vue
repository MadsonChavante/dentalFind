<template>
  <div class="hello">
    <Topo />
    <busca />
    <Categorias/>
    <hr style="height:1px; border:none; color:#c3c3c3; background-color:#f5f5f5; margin: 100px; margin-bottom: 0px;"/>
    <div class="texto">Dá uma olhada nas nossas sugestões:</div>
    <div class="teste">
      <Card v-for="produto in itens" v-bind:todo="produto" v-bind:key="produto.id" />
    </div>
    <hr style="height:1px; border:none; color:#c3c3c3; background-color:#f5f5f5; margin: 100px; margin-bottom: 0px;"/>
    <div class="texto">Por que DentalFind ?</div>
    <div class="c">
      <img  class="logo" src="@/assets/c.png" />
    </div>
    <Rodape/>
  </div>
</template>

<script>

import Topo from '@/components/Topo'
import Busca from '@/components/Busca-logo'
import Categorias from '@/components/Categorias'
import Card from '@/components/Card_produto'
import Rodape from '@/components/Rodape'


export default {
  name: 'Home',
  components: { Topo, Busca, Categorias, Card, Rodape },
  created: function(){

  this.axios.get("http://localhost:18612/produtos/sugestoes")
    .then(this.SuccessGet)
    .catch(console.log(""));

  },
  methods:{
    SuccessGet: function (dataR) {
      console.log(dataR)
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
  },
  data () {
    return {
      itens:[]
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
::-webkit-scrollbar {
  width: 1px;
  height: 1px;
}

::-webkit-scrollbar-button {
  width: 1px;
  height: 1px;
}

*,
*::after,
*::before {
  box-sizing: border-box;
}
.texto{
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
  font-size: 20px;
  color: #00b0f0;
  text-align: center;
}
.teste{
  margin-top: 50px;
  display: flex;
  overflow-x: scroll;
  justify-content: center;
  align-items: center;
  height: 300px;
}
.c{
  margin-top: 50px;
}
.c>img{
  width: 100%;
  height: auto;
}
/*tablet*/
@media screen and (max-width: 768px) {
  .teste{
    justify-content: flex-start;
  }
}
/*celular*/
@media screen and (max-width: 425px) {
  .sugestao{
    width: 300px;
  }
}
</style>
