<template>
    <div @click="go">
      <div class="sugestao">
        <div class="img">
          <img :src="todo.imagem"/>
        </div>
        <div class="titulo">
          {{ todo.titulo }}
        </div>
      </div>
    </div>
</template>

<script>


export default {
  data () {
    return {
      url:"produto/" + this.todo.id
    }
  },
  name: 'Sugestao',
  props: ['todo'],
  methods:{
    go: function (){
      this.$router.push('/produto/'+this.todo.id)
    }
  }
}
</script>

<style lang="css" scoped>
.sugestao{
  margin-top: -4px;
  border: 0.2px solid #f3f1f1;
  z-index: 1;
  display: flex;
  width: 500px;
  height: 70px;
  background-color: #fff;
  font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
  align-items: center;
  justify-content: flex-start;
  padding: 5px;
}
.sugestao:hover{
  background-color: #f3f1f1;
}
.titulo{
  margin-left: 10px;
}
img{
  width: 50px;
  height: 50px;
}
/*tablet*/
@media screen and (max-width: 768px) {
  .sugestao{
    width: 400px;
  }
}
/*celular*/
@media screen and (max-width: 425px) {
  .sugestao{
    width: 300px;
  }
}
</style>
