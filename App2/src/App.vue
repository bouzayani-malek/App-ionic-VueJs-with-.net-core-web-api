<template>
  <ion-app>
    <menu-side></menu-side>
    <ion-router-outlet id="main" />
  </ion-app>
</template>
<script>
import MenuSide from"./components/MenuSide.vue"

import { IonApp, IonRouterOutlet } from '@ionic/vue';
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'App',
  components: {
    IonApp,
    IonRouterOutlet,
    MenuSide
  }
});
</script>