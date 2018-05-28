<template>

  <div>
    <Topo />
    <div class="container-categorias">
      <LCategorias v-for="categoria in itens" v-bind:todo="categoria" v-bind:key="categoria.id" />
    </div>
  </div>
</template>

<script>
import LCategorias from '@/components/listar-categorias'
export default {
  name: 'Categorias',
  components: { LCategorias },
  data () {
    return {
      itens: []
    }
  },
  methods: {
    getCategorias: function () {
      // GET
      var invocation = new XMLHttpRequest();
      this.axios.get("http://localhost:18612/categorias", )
        .then(this.SuccessGet)
        .catch(FailureGet);
    },
    SuccessGet: function (dataR) {
      console.log(dataR);
      for (var i = 0; i < dataR.data.length; i++) {
        this.itens.push({ titulo: dataR.data[i].titulo, imagem: dataR.data[i].imagem, id: dataR.data[i].id});
      }
    }
  },
  mounted: function(){
    this.getCategorias();
  }
}
function FailureGet (data) { console.log('error', data); }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
@media screen and (max-width: 425px) {
  .container-categorias{
    display: none;
  }
}
.container-categorias{
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  width: 100%;
  justify-content: center;
}
</style>
