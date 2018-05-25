<template>
  <div>
    <div id="pesquisa">
      <input id="p" autocomplete="off" class="pesquisa" type="search" v-model="value" v-on="listeners" placeholder="Pesquise" @keyup.enter="goPesquisa" v-on:keyup="getSugestoes" >
      <div class="img" @click="goPesquisa">
        <img :src="'./static/img/search.png'"/>
      </div>
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
      value:'',
      message: '',
      itens: []
    }
  },
  methods: {
    goPesquisa: function () {
      if(this.value.length > 2){
        this.$router.push('/pesquisa/'+this.value)
        location.reload();
      }
    },
    getSugestoes: function () {
      this.itens = [];
      if(this.value !== "" && this.value.length > 3){
        this.axios.get("http://localhost:18612/sugestoes/"+this.value)
          .then(this.SuccessGet)
          .catch(console.log(""));
      }
    },
    SuccessGet: function (dataR) {
      for (var i = 0; i < dataR.data.length; i++) {
        this.itens.push({ titulo: dataR.data[i].titulo, imagem: dataR.data[i].imagem, id: dataR.data[i].id });
      }
    },

  },
  computed: {
  listeners () {
      return {
        // Passa todas as escutas do componente diretamente ao input
        ...this.$listeners,
        // Sobrescreve a escuta `input` para funcionar com v-model
        input: event => this.$emit('input', event.target.value)
      }
    }
  }
}
</script>

<style lang="css" scoped>
.img{
  display: flex;
  align-items: center;
  justify-content: center;
  height: auto;
  width: 40px;
  border-radius: 20px;
  -webkit-transition:2s;
}
.img>img{
  width: 20px;
  height: 20px;
}
.img:hover{
  background-color: chartreuse;
}
#pesquisa {
  display: flex;
  height: 40px;
  width: 500px;
  background: white;
  border-radius: 5px;
  box-shadow: 0 0 1em #808080;
  padding: 5px;
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

/*tablet*/
@media screen and (max-width: 768px) {
  #pesquisa{
    width: 400px;
  }
  .pesquisa{
    width: 90%;
  }
}
/*celular*/
@media screen and (max-width: 425px) {
  #pesquisa{
    width: 300px;
  }
  .pesquisa{
    width: 90%;
  }
}
</style>
