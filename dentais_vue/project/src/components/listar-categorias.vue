<template>
  <div class="card-categoria">
    <div class="titulo">
      {{ todo.titulo }}
    </div>
    <div class="img">
      <img :src="todo.imagem"/>
    </div>
  </div>
</template>

<script>

export default {
  name: 'LCategorias',
  props: ['todo'],
}


</script>

<style lang="css" scoped>
.card-categoria {
  width: 120px;
  height: 150px;
  margin: 10px;
  text-align: center;
  margin-top: 10px;
  border-radius: 4px;
  border: 1px solid #076964bd;
  box-shadow: inset 0 2px 3px 0 rgba(255, 255, 255, 0.3),
    inset 0 -3px 6px 0 rgba(0, 0, 0, 0.2), 0 3px 2px 0 rgba(0, 0, 0, 0.2);
  background-image: linear-gradient(to bottom, #02615cb4, #076964bd 130%);
}
.titulo {
  margin-top: 10px;
  color: beige;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
    Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
}
.imagem{

}
</style>
