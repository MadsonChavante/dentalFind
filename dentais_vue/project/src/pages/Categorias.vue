<template>
  <div>
    <Topo />
    <div class="categorias">
      <LCategorias v-for="categoria in itens" v-bind:todo="categoria" v-bind:key="categoria.id" />
    </div>
  </div>
</template>
<script>

import Topo from '@/components/Topo'
import LCategorias from '@/components/listar-categorias'

export default {
  name: 'Categorias',
  components: { Topo, LCategorias },
  data () {
    return {
      itens: []
    }
  },
  methods: {
    getCategorias: function () {
      // GET
        this.axios.get("http://localhost:18612/categorias", )
          .then(this.SuccessGet)
          .catch(FailureGet);
    },
    SuccessGet: function (dataR) {
      console.log(dataR);
      for (var i = 0; i < dataR.data.length; i++) {
        this.itens.push({ titulo: dataR.data[i].titulo, imagem: dataR.data[i].imagem });
      }
    },
    FailureGet:function(data) { console.log('error', data); }
  },
  mounted: function(){
    this.getCategorias();
  }
}


</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.categorias{
  display: flex;
  padding: 20px;
  padding-top: 60px;
}
</style>
