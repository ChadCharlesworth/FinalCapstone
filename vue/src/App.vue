<!--<template>
  <div id="app" class="container">
    <header-panel class="header-panel" />
    <left-column class="left" />
    <right-column class="right" />
    <main-panel class="main" />
  </div>
</template> -->

<template>
  <div id="app">
    <header-panel id="nav"/>
    <div class="container-fluid">
      <div class="row">
        <left-column class="col-lg-2 col-sm-2 left-column border border-dark" style="height:100vh;"/>
        <main-panel class="col-lg-8 col-sm-2 main"/>
        <right-column class="col-lg-2 col-sm-4 right-column border border-dark"/>
    </div>
  </div>
  </div>
</template>

<script>
import HeaderPanel from './views/HeaderPanel.vue';
import LeftColumn from './views/LeftColumn.vue';
import MainPanel from './views/MainPanel.vue';
import RightColumn from './views/RightColumn.vue';

export default {
  components: { HeaderPanel, RightColumn, LeftColumn, MainPanel  },
}
</script>

<!-- <style scoped>
.container {
    display: grid;
    grid-template-columns: 1fr 4fr 1fr;
    grid-template-areas: 
        "header header header"
        "left-column main-panel right-column";
    height: 100vh;
    grid-gap: 10px;
}

.header-panel {
    grid-area: header;
}

.left {
    grid-area: left-column;
}

.main {
    grid-area: main-panel;
}

.right {
    grid-area: right-panel;
}

</style> -->