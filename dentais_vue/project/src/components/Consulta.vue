<template>
  <div class="contenier_c">
    <div class="card">
      <div class="c_logo">
        <img :src="'./static/img/'+todo.titulo+'.png'" />
      </div>
      <div class="preco">
        <div class="desc" :title= todo.descricao>
          {{todo.descricao}}
        </div>
        <h1>{{todo.respostaString}}</h1>
      </div>
      <div id=but>
        <a class="but" v-bind:href="todo.site" target="_blank">
          Ir á loja
        </a>
      </div>
    </div>
  </div>
</template>

<script>

export default {
  data(){
    return{

    }
  },
  name: 'Consulta',
  props: ['todo'],
}
</script>

<style lang="css" scoped>
.contenier_c {
  display: flex;
  justify-content: center;
}
.card {
  text-align: center;
  border-radius: 10px;
  display: flex;
  justify-content:space-between;
  align-items: center;
  margin-top: 30px;
  width: 700px;
  height: 80px;
  background-color: #f3f2f2;
}
.c_logo {
  box-shadow: 0px 0px 15px #c3c3c3;
  margin-left: 20px;
  display: flex;
  justify-content: center;
  align-items: center;
  width: 60px;
  height: 60px;
  border-radius: 30px;
  background-color: white;
}
.c_logo > img {
  width: 80%;
  height: auto;
}
.preco {
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
    Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
  color: #24b1bb;
}
.desc{
  color: grey;
  width: 400px;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}
.but{
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
    Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
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
  margin-right: 20px;
}
.but:hover{
  box-shadow: 0px 0px 15px #c9c9c9;
  color: darkgrey;
}

/*tablet*/
@media screen and (max-width: 768px) {
  .desc{
    display: none;
  }
}
/*celular*/
@media screen and (max-width: 425px) {
  .card {
    width: 100%;
    font-size: 13px;
  }
}
</style>
