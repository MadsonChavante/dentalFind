<template>
  <div class="corpo">
    <Topo />
    <div class="superior">
      <div class="logo">
        <img class="img" :src="'./static/'+imagem">
        <div id="l" class="container">
          <div class="dot dot-1"></div>
          <div class="dot dot-2"></div>
          <div class="dot dot-3"></div>
          </div>

          <svg xmlns="http://www.w3.org/2000/svg" version="1.1">
          <defs>
            <filter id="goo">
              <feGaussianBlur in="SourceGraphic" stdDeviation="10" result="blur" />
              <feColorMatrix in="blur" mode="matrix" values="1 0 0 0 0  0 1 0 0 0  0 0 1 0 0  0 0 0 21 -7"/>
            </filter>
          </defs>
          </svg>
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
      titulo:'',
      cat:'',
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
      var e = document.querySelector('.logo>img');
      e.style.display = 'block';
      setTimeout(function () {
        console.log("entrou ");
        e = document.getElementById('l');
        e.style.display = 'none';
      }, 2000)
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
  margin-top: 30px;
  padding: 5px;
  background-color: #ffffff;
}
.logo>img{
  display: none;
  width: 70px;
  height: 70px;

}
.cabecalho{
  margin-top: 20px;
  margin-left: -90px;
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


.container {
  width: 200px;
  height: 200px;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  margin: auto;
  filter: url('#goo');
  animation: rotate-move 2s ease-in-out infinite;
  margin-top: 50px;
}

.dot {
  width: 70px;
  height: 70px;
  border-radius: 50%;
  background-color: #000;
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  margin: auto;
}

.dot-3 {
  background-color: #f74d75;
  animation: dot-3-move 2s ease infinite, index 6s ease infinite;
}

.dot-2 {
  background-color: #10beae;
  animation: dot-2-move 2s ease infinite, index 6s -4s ease infinite;
}

.dot-1 {
  background-color: #ffe386;
  animation: dot-1-move 2s ease infinite, index 6s -2s ease infinite;
}

@keyframes dot-3-move {
  20% {transform: scale(1)}
  45% {transform: translateY(-18px) scale(.45)}
  60% {transform: translateY(-90px) scale(.45)}
  80% {transform: translateY(-90px) scale(.45)}
  100% {transform: translateY(0px) scale(1)}
}

@keyframes dot-2-move {
  20% {transform: scale(1)}
  45% {transform: translate(-16px, 12px) scale(.45)}
  60% {transform: translate(-80px, 60px) scale(.45)}
  80% {transform: translate(-80px, 60px) scale(.45)}
  100% {transform: translateY(0px) scale(1)}
}

@keyframes dot-1-move {
  20% {transform: scale(1)}
  45% {transform: translate(16px, 12px) scale(.45)}
  60% {transform: translate(80px, 60px) scale(.45)}
  80% {transform: translate(80px, 60px) scale(.45)}
  100% {transform: translateY(0px) scale(1)}
}

@keyframes rotate-move {
  55% {transform: translate(-50%, -50%) rotate(0deg)}
  80% {transform: translate(-50%, -50%) rotate(360deg)}
  100% {transform: translate(-50%, -50%) rotate(360deg)}
}

@keyframes index {
  0%, 100% {z-index: 3}
  33.3% {z-index: 2}
  66.6% {z-index: 1}
}




/*tablet*/
@media screen and (max-width: 768px) {
  .cabecalho{
    font-size: 11px;
    margin-top: -20px;
    margin-left: -20px;
  }
  .cabecalho>div{
    height: 20px;
  }
  .logo{
    width: 60px;
    height: 60px;
    margin-top: 5px;
    margin-left: 20px;
  }
  .logo>img{
    width: 50px;
    height: 50px;

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
