<template>
  <div id="app" class="container">
    <header-panel class="header-panel" />
    <left-column class="left" />
    <right-column class="right" />
    <main-panel class="main" />
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

<style scoped>
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

</style>