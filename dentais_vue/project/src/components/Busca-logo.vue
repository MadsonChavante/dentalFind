<template>
  <div class="contenier" style="background-image: url('./static/img/background-doutor1.png');">
    <img :src="'./static/img/logo2.png'"/>
    <div class="pesquisa">
      <Pesquisar/>
    </div>
  </div>
</template>

<script>
import Pesquisar from '@/components/Pesquisar'
export default {
  name: 'Busca',
  components: {Pesquisar}
}
</script>

<style lang="css" scoped>
.contenier {
  position:static;
  width: 100%;
  height: 300px;
  padding-left: auto;
  padding-right: auto;
  display: flex;
  align-items: center;
  flex-direction: column;
  background-color: #24b1bb;
  background-repeat:no-repeat,repeat-y;
  background-image: 300px;
}
.contenier>img{
  margin-top: 60px;
  width: 350px;
  height: 110px;
}
.pesquisa{
  display: flex;
  margin-top: 0px;
}
/*tablet*/
@media screen and (max-width: 768px) {
  .contenier{
    height: 210px;
  }
  .contenier>img{
    margin-top: 0px;
    width: 150px;
    height: 50px;
}
}
</style>

