<template>
  <div class="contenier">
    <img :src="'./static/img/logo.png'"/>
    <Pesquisar/>
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
  position: static;
  width: 100%;
  height: 250px;
  display: flex;
  align-items: center;
  flex-direction: column;
  background-color: #24b1bb;
}

.contenier>img{
  margin-top: 50px;
  width: 250px;
  height: 100px;
}
/*tablet*/
@media screen and (max-width: 768px) {
  .contenier{
    height: 210px;
  }
  .contenier>img{
    margin-top: 0px;
    width: 150px;
    height: 60px;
}
}
</style>
