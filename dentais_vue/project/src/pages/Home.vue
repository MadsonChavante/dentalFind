<template>
  <div class="hello">
    <Topo />
    <busca />
  </div>
</template>

<script>

import Topo from '@/components/Topo'
import Busca from '@/components/Busca-logo'

export default {
  name: 'Home',
  components:{Topo,Busca},
  data () {
    return {
      msg: 'Welcome to Your Vue.js App'
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
