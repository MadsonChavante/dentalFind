<template>
  <div>
    <Topo/>
    <div class="contenier">
      <div class="card">
        <div class="contenier">
          <div class="img">
            <img :src= produto.imagem alt="">
          </div>
          <div class="info">
            <div class="title">
              <h2>{{produto.titulo}}</h2>
            </div>
            <div class="preco">
              <h1>{{produto.melhorConsulta.preco}}</h1>
            </div>
            <div id=but >
              <a class="but" v-bind:href="produto.melhorConsulta.site">
                Ir á loja
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="i_contenier">
      <div class="i_conteudo">
        <div class="ii">
          Encontramos preços
        </div>
        <div class="iii">
          em {{produto.consultas.length}} lojas.
        </div>
      </div>
    </div>
    <Consulta v-for="consulta in produto.consultas" v-bind:todo="consulta" v-bind:key="consulta.id"/>
  </div>
</template>

<script>
import Topo from '@/components/Topo'
import Consulta from '@/components/Consulta'
export default {
  data () {
    return {
      produto: {
        titulo: '',
        imagem: '',
        consultas: [],
        melhorConsulta: {}
      }
    }
  },
  components: { Topo,Consulta },
  name: 'Produto',
  created: function () {
    this.axios.get("http://localhost:18612/produtos/" + this.$route.params.id, )
      .then(this.SuccessGetP)
      .catch(this.FailureGet);
    this.axios.get("http://localhost:18612/produtos/" + this.$route.params.id + "/consultas", )
      .then(this.SuccessGetC)
      .catch(this.FailureGet);
  },
  methods: {
    SuccessGetP: function (dataR) {
      this.produto.titulo = dataR.data[0].titulo;
      this.produto.imagem = dataR.data[0].imagem;
    },
    SuccessGetC: function (dataR) {
      console.log(dataR);
      for (var i = 0; i < dataR.data.length; i++) {
        this.produto.consultas.push({ preco: dataR.data[i].preco, titulo: dataR.data[i].titulo, descricao: dataR.data[i].descricao, site: dataR.data[i].site  });
        if(i==0){
          this.produto.melhorConsulta = { preco: dataR.data[0].preco, titulo: dataR.data[0].titulo, descricao: dataR.data[0].descricao, site: dataR.data[0].site}
        }
        else{
          if( (this.sTI(this.produto.melhorConsulta.preco)) > (this.sTI(this.produto.consultas[i].preco) ) ){
            this.produto.melhorConsulta = { preco: dataR.data[i].preco, titulo: dataR.data[i].titulo, site: dataR.data[0].site }
          }
        }
      }
    },
    FailureGet: function (data) { console.log('error', data); },
    sTI: function (numero) {
      if(numero !== null){
        numero = numero.replace("R$","");
        numero = numero.replace(".","");
        numero = numero.replace(",","");
        numero = parseInt(numero);
        return numero;
      }
    }
  },

}
</script>
<style scoped>
.contenier {
  display: flex;
  justify-content: center;
  background-color: #f3f2f2;
  width: unset;
  height: 300px;
}
.card {
  border-radius: 5px;
}
.title {
  text-align: center;
  border-radius: 5px;
  color: rgb(80, 80, 80);
  background-color: #ffffff;
  margin-top: 50px;
}
.img {
  display: flex;
  justify-content: center;
  margin-top: 20px;
  border-radius: 5px;
  width: calc(59% - 10px);
  height: 250px;
  background-color: #ffffff;
  padding: 5px;
}
.img > img {
  margin-top: 20px;
  width: 60%;
  height: auto;
}
.info {
  text-align: center;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
    Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
  padding: 5px;
  margin-top: 20px;
  margin-left: 20px;
  border-radius: 5px;
  width: 40%;
  height: 250px;
  background-color: #ffffff;
}
.preco{
  margin-top: 10px;
  color: #24b1bb;
}
.but{
  padding: 5px;
  box-shadow: 0px 0px 5px #c3c3c3;
  color: white;
  font-weight:bold;
  text-decoration: initial;
  background-color: yellow;
  width: 100px;
  height: 30px;
}
#but{
  margin-top: 20px;
}
.but:hover{
  box-shadow: 0px 0px 15px #c9c9c9;
  color: darkgrey;
}
.i_contenier{
  display: flex;
  justify-content: center;
  margin-top: 30px;
}
.i_conteudo{
  background-color: #24b1bb;
  width: 250px;
  border-radius: 10px;
  font-weight:bold;
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
  padding: 5px;
  display: flex;
}
.ii{
  color: white;
}
.iii{
  margin-left: 10px;
  color: chartreuse;
}

</style>
