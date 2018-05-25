<template>
<div class="contenier_produtos">
  <div @click="go">
      <div class="card_produto">
        <div class="img_produto">
          <img :src="todo.imagem">
        </div>
        <hr style="height:1px; border:none; color:#c3c3c3; background-color:#c3c3c3; margin-top: 0px; margin-bottom: 0px;"/>
        <div class="info_produto">
          <h4>{{todo.titulo}}</h4>
          <h3>{{precoString}}</h3>
          <h6>Economize: R${{todo.economia}}</h6>
        </div>
      </div>
  </div>
</div>
</template>
<script>
export default {
  name: 'Card',
  props: ['todo'],
  created: function (){
    console.log(this.consultaId);
    this.axios.get("http://localhost:18612/consulta/"+this.consultaId+"")
    .then(this.SuccessGet)
    .catch();
  },
  methods: {
    go: function () {

      this.$router.push('/produto/'+this.todo.id)
    },
    SuccessGet: function (data) {
      this.precoString = data.data.respostaString
    }
  },
  data () {
    return {
       url:"produto/" + this.todo.id,
       precoString:'',
       consultaId: this.todo.consultaId
    }
  }
}
</script>

<style scoped>

.contenier_produto{
  display: flex;
  flex-direction: row;
  z-index: -1;
}
.card_produto{
  margin: 10px;
  padding: 10px;
  width: 150px;
  height: 205px;
  background-color:#fff;
  box-shadow: 0px 0px 5px #c3c3c3;
}
.img_produto{
  display: flex;
  justify-content: center;
  z-index: -1;
  position: static;
}
.img_produto>img{
  width: 80%;
  height: 80%;
  -webkit-transition:1s;
}
.img_produto>img:hover{
  width: 90%;
  height: 90%;
}
.info_produto{
  height:76px;
  margin-top: -1px;
  white-space: nowrap;
}
.info_produto>h4{
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
  margin-top: 6px;
  color: #6f7e80;
  overflow: hidden;
  text-overflow: ellipsis;
}
.info_produto>h3{
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
  margin-top: 4px;
  color: #24b1bb;
}
.info_produto>h6{
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
  margin-top: -3px;
  color: rgb(167, 194, 145);
}

</style>
