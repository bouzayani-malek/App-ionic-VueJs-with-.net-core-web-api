<template>
  <ion-card>
    <ion-card-header style="text-align: center">
        <slot name="slot-1" />
      
    </ion-card-header>
  </ion-card>
</template>

<script>
import { IonCard, IonCardHeader } from "@ionic/vue";
import { defineComponent } from "vue";

export default defineComponent({
  data() {
    return {};
  },
  components: {
    IonCard,

    IonCardHeader,
  },
});
</script>
<style>
</style>