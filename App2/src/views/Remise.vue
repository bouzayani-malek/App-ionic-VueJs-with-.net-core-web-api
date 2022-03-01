<template>
  <ion-page>
    <base-layout>
      <template v-slot:slot-1>Remise Livre</template>
      <template v-slot:slot-2>
        <ion-buttons slot="start">
          <ion-button color="danger">
            <ion-menu-button menu="main-menu"></ion-menu-button>
          </ion-button>
        </ion-buttons>
      </template>
    </base-layout>

    <ion-content :fullscreen="true">
      <!--chercher les etudiants -->
      <ion-item>
        <ion-label position="floating">Nom de l'étudiant</ion-label>
        <ion-input
          v-model="nomEtudiant"
          type="text"
          placeholder=""
          required
        ></ion-input>
      </ion-item>
      <!--affiche resultas -->
      <chercher-layout
        v-for="etudiant in EtudiantsSh"
        :key="etudiant.idEtudiant"
        @click="
          choisitEtudiant(etudiant.idEtudiant, etudiant.nom, etudiant.prenom)
        "
      >
        <template v-slot:slot-1>
          <ion-label color="success">
            {{ etudiant.nom }} {{ etudiant.prenom }}</ion-label
          >
        </template>
      </chercher-layout>
      <!--chercher les etudiants -->

      <ion-item>
        <ion-label position="floating">Ref ou Nom du livre :</ion-label>
        <ion-input
          v-model="nomLivre"
          type="text"
          placeholder=""
          required
        ></ion-input>
      </ion-item>
      <chercher-layout
        v-for="livre in LivreSh"
        :key="livre.idLivre"
        @click="choisitLivre(livre.idLivre, livre.titre)"
      >
        <template v-slot:slot-1>
          <ion-label color="success"> {{ livre.titre }}</ion-label>
        </template>
      </chercher-layout>

      <div class="app3">
        <ion-buttons>
          <ion-button color="danger" @click="Remise()" href="/home">
            Remise
            <ion-icon :icon="add"></ion-icon>
          </ion-button>
        </ion-buttons>
      </div> 
      
    </ion-content>
  </ion-page>
</template>

<script>
import { mapGetters } from "vuex";
import BaseLayout from "../components/BaseLayout.vue";
//import CardEtudiant from "../components/CardEtudiant.vue";
import { IonPage, IonButtons, IonButton, IonInput } from "@ionic/vue";
import { add } from "ionicons/icons";
import { defineComponent } from "vue";
import ChercherLayout from "../components/ChercherLayout.vue";
//import axios from "axios";

export default defineComponent({
  data() {
    return {
      add,
      EtudiantsSh: "",
      nomEtudiant: "",
      idE: "",
      nomLivre: "",
      LivreSh: "",
      idL: "",
      empreint: "",
      idEmpreint: "",
      du: "",
    };
  },
  methods: {
    choisitEtudiant(id, nom, prenom) {
      this.idE = id;
      this.nomEtudiant = nom + " " + prenom;
    },
    choisitLivre(id, titre) {
      this.idL = id;
      this.nomLivre = titre + " ";
    },
    Remise() {
      // axios
      //   .get("https://localhost:44300/api/Livres/" + this.idL)
      //   .then((res) => {
      //     this.empreint = res.data.empreint;

      //     this.idEmpreint = this.empreint.filter((el) => el.au==null && el.idEtudiant==this.idE).map(el=>
      //     el.idEmpreinte
         
      //     );

      //     //axios
      //     axios
      //       .get("https://localhost:44300/api/empreints/" + this.idEmpreint[0])
      //       .then((res) => {
      //         //this.idEmpreint=res.data;
      //         const current = new Date();
      //         const date =
      //           current.getFullYear() +
      //           "-" +
      //           (current.getMonth() + 1) +
      //           "-" +
      //           current.getDate();
      //         let remise = {
      //           idEmpreinte: this.idEmpreint[0],
      //           idLivre: this.idL,
      //           idEtudiant: this.idE,
      //           du: res.data.du,
      //           au: date,
      //         };
      //         axios.put("https://localhost:44300/api/empreints/"+this.idEmpreint[0],remise);
      //       });
      //   });

        },
  },
  watch: {
    nomEtudiant() {
      if (this.nomEtudiant !== "") {
        this.EtudiantsSh = this.listeEtudiant.filter(
          (s) =>
            s.prenom.startsWith(this.nomEtudiant) ||
            s.nom.startsWith(this.nomEtudiant)
        );
      } else {
        this.EtudiantsSh = "";
      }
    },
    nomLivre() {
      if (this.nomLivre !== "") {
        this.LivreSh = this.listeLivre.filter(
          (s) =>
            s.titre.startsWith(this.nomLivre) ||
            s.isbm.startsWith(this.nomLivre)
        );
      } else {
        this.LivreSh = "";
      }
    },
  },

  computed: {
    ...mapGetters(["listeEtudiant", "listeLivre"]),
  },
  mounted() {
    this.$store.dispatch("Get_Etudiant");
    this.$store.dispatch("Get_Livre");
  },

  components: {
    IonPage,
    IonButtons,
    IonButton,
    BaseLayout,
    IonInput,
    ChercherLayout,
  },
});
</script>
<style>
ion-content {
  --padding-top: 80px;
}
.app3 {
  width: 31%;
  margin-top: 20px;
  margin-left: 35%;
  text-align: center;
  background-color: #e5c234;
  border-radius: 20px;
}
</style>
