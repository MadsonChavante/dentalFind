<template>
<div>


   <div class="card-simple">
    <router-link class="title" :to="{path:'categoria/' + todo.id }">
    <img class="img" :src="'./static/'+todo.imagem">
      {{ todo.titulo }}
    </router-link>
     </div>



</div>


</template>

<script>
export default {
  name: "LCategorias",
  props: ["todo"],
  data(){

      console.log(this.todo)
    return{
    }
  }
};
</script>

<style>
  .img{
    margin: 4px;
    width: 50px;
    height: 50px;
  }
  .card-simple{
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    margin: 5px;
    width: 15em;
    height: 5em;
    justify-content: center;
    background-color: #F8F8F8;
    z-index: 10;
  }
  .title{
    display: flex;
    align-items: center;
    justify-content: center;
    color: rgb(80, 80, 80);
      background-color: #F8F8F8;
      text-decoration: none!important;
      margin: 4px;
      font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
      font-size: 18px;
  }
  @media screen and (max-width: 425px) {
  .card-simple{
    display: none;
  }
}
</style>
