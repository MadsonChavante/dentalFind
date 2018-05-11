<template>
  <div class="contenier">
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
  width: 100%;
  height: 300px;
  padding-left: auto;
  padding-right: auto;
  display: flex;
  align-items: center;
  flex-direction: column;
  background-color: #24b1bb;
}

</style>
