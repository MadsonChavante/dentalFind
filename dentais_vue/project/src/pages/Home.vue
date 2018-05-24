<template>
  <div class="hello">
    <Topo />
    <busca />
    <div class="teste">
      <Card v-for="produto in itens" v-bind:todo="produto" v-bind:key="produto.id" />
    </div>
  </div>
</template>

<script>

import Topo from '@/components/Topo'
import Busca from '@/components/Busca-logo'
import Card from '@/components/Card_produto'

export default {
  name: 'Home',
  components: { Topo, Busca, Card },
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

.teste{
  display: flex;
  overflow-x: scroll;
  justify-content: center;
  align-items: center;
  height: 300px;
}

</style>
