<template>
    <div> 
        <html>
            <head>

            </head>
            <body>
                <h2>Instrutor Table</h2>
                <table style="width: 100%">
                    <tr>
                        <th class="table-heading">First Name</th>
                        <th class="table-heading">Middle Initial</th>
                        <th class="table-heading">Last Name</th>
                    </tr>
                    <tbody id="instrutorTable">
                        <tr v-for="instrutor in instrutors" v-bind:key="instrutor.firstName">
                            <td>{{instrutor.firstName}}</td>
                            <td>{{instrutor.middleName}}</td>
                            <td>{{instrutor.lastName}}</td>
                        </tr>
                    </tbody>
                </table> 
            </body>
        </html>
    </div>
</template>

<script>
export default {
  name: 'Instrutors',
  mounted() {
      this.instrutors = getInstrutors();
  },

  data() {
      return{
          instrutors:[]
      }
  }
}

function getInstrutors() {
    return JSON.parse(instrutors);

}
var instrutors = '{"instrutors": [{"firstName": "Aaron", "middleInitial": "W." , "lastName": "Whistler" }, {"firstName": "Jake", "middleInitial": "B." , "lastName": "Vandargeer" }]}'
</script>

<style scoped>
    #first-section{
        font-size: 16pt;
        color: blue
    }

    #second-section{
        font-size: 16pt;
        color:greenyellow
    }
    #third-section{
        font-size: 16pt;
        color:purple
    }


    p {
        color: red;
        text-align: center;
    }

    a {
        font-family: monospace;
        font-weight: bold;
        font-size: 14pt;
    }

    .links {
        background-color: lightgray;
        margin-top: 20px;
        padding: 10px;
    }

    span {
        padding-right: 20px;
    }
</style>