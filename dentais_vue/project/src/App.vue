<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<script >
export default {
  name: 'App'
}
</script>

<style>
*{
  margin: 0;
  padding: 0;
}

.resulatdos{
  position: relative;
  z-index: 1;
}
.sugestao{
  position: relative;
  z-index:5;
}
</style>
