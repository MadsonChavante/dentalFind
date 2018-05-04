<template>
  <div class="contenier">
    <div id="pesquisa">
      <input class="pesquisa" type="search" placeholder="Pesquise" />
    </div>
  </div>
</template>

<script>
export default {
  name: 'Busca'
}
</script>

<style lang="css" scoped>
.contenier {
  width: 100%;
  height: 300px;
  display: flex;
  align-items: center;
  flex-direction: column;
  background-color: #24b1bb;
}
#pesquisa{
  margin-top: 95px;
  height: 40px;
  width: 40%;
  background: white;
  border-radius: 5px;
  box-shadow: 0 0 1em #808080;
  padding: 5px;
}
.pesquisa{
  background-color: transparent;
    border: none;
    border-radius: 0;
    outline: none;
    height: 3rem;
    width: 100%;
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
</style>
