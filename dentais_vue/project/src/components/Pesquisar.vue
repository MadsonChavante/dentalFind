<template>
  <div>
    <div id="pesquisa">
      <input id="p" class="pesquisa" type="search" placeholder="Pesquise" v-on:keyup="getSugestoes" >
    </div>
    <div class="sugestoes">
      <Sugestao v-for="categoria in itens" v-bind:todo="categoria" v-bind:key="categoria.id" />
    </div>
  </div>
</template>

<script>
import Sugestao from '@/components/Sugestao';

export default {
  name: 'Pesquisar',
  components: {
    'Sugestao': Sugestao
  },
  data () {
    return {
      message: '',
      itens: []
    }
  },
  render: function () {
    console.log("algo");
    return ""
  },
  methods: {
    getSugestoes: function () {
      this.itens = [];
      var algo = document.getElementById('p').value;
      if(algo !== ""){
        this.axios.get("http://localhost:18612/pesquisar/"+algo)
          .then(this.SuccessGet)
          .catch(console.log(""));
      }
    },
    SuccessGet: function (dataR) {
      console.log(dataR);
      for (var i = 0; i < dataR.data.length; i++) {
        this.itens.push({ titulo: dataR.data[i].titulo, imagem: dataR.data[i].imagem, id: dataR.data[i].id });
      }
    },

  },
  mounted: function () {
    //this.getSugestoes();
  }
}
</script>

<style lang="css" scoped>
#pesquisa {
  margin-top: 95px;
  height: 40px;
  width: 500px;
  background: white;
  border-radius: 5px;
  box-shadow: 0 0 1em #808080;
  padding: 5px;
}
@media screen and (max-width: 828px) {
  #pesquisa{
    width: 400px;
  }
}
@media screen and (max-width: 600px) {
  #pesquisa{
    width: 300px;
  }
}
.pesquisa {
  background-color: transparent;
  border: none;
  border-radius: 0;
  outline: none;
  height: 3rem;
  width: 500px;
  font-size: 1rem;
  margin: 0 0 20px 0;
  padding: 0;
  -webkit-box-shadow: none;
  box-shadow: none;
  -webkit-box-sizing: content-box;
  box-sizing: content-box;
  -webkit-transition: all 0.3s;
  transition: all 0.3s;
}
.sugestoes{
  display: flex;
  flex-direction: column;
  align-items: center;
}
</style>
