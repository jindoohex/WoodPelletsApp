url = "http://localhost:5099/api/WoodPellets"

Vue.createApp({
    data() {
        return {
            // Add data here
            woodPelletList:[],
            id: 0,
            brand: "",
            price: null,
            quality: null,
            errorMessage: null,
            WoodPelletSort: "asc"

        }
    },

    created() {
        // created() is a life cycle method, not an ordinary method
        // created() is called automatically when the page is loaded
        console.log("Created method called")

    },

    computed: {
        // Add getter properites (computed properties)
        
    },
    
    methods: {
        // Add methods here
        clearCurrentList()
        {
            this.woodPelletList = []
        },

        getAllWoodPellets()
        {
            this.errorMessage = null
            axios.get(url)
            .then(response =>
                {
                    console.log(response)
                    this.woodPelletList = response.data
                    console.log("Status code: " + response.status)
                })

                .catch(error = (ex) =>
                {
                    this.woodPelletList = []
                    this.error = ex.message
                    console.log("Error: " + this.error)
                })
        },

        postWoodPellet()
        {
            console.log("bums")
            axios.post(url, {"id": this.id, "brand": this.brand, "price": this.price, "quality": this.quality})
            .then(response =>
                {
                    console.log("URI: " + url)
                    console.log("Function >>postWoodPellet<< was called.")
                    console.log("Status code: " + response.status)

                    this.status = response.status
                })
                
                .catch(error = (ex) =>
                {
                    this.woodPelletList = []
                    this.errorMessage = ex.message
                    console.log("Error: " + this.errorMessage)
                })
        },

        getWoodPelletById(id)
        {
            this.errorMessage = null
            uri = url + "/" + id
            axios.get(uri)
            .then(response => 
                {
                    console.log(id);
                    console.log(response);
                    console.log("URI: " + uri)
                    console.log("Function >>getWoodPelletById<< was called.")
                    console.log("Status code: " + response.status)

                    this.woodPelletList = []
                    if (response.status == 200)
                    {
                        this.woodPelletList.push(response.data)
                    }
                    if (response.status == 204)
                    {
                        this.errorMessage = ("No content with status code " + response.status)
                    }
                    // Max value on int is 2,147,483,647
                    // so if the requested ID is higher than this, it pimps the stack
                    this.status = response.status
                })
                .catch(error = (ex) =>
                {
                    console.log(ex);
                    this.woodPelletList = []
                    this.errorMessage = ex.message
                    console.log("Error: " + this.errorMessage)
                })
        },

        sortById()
        {
            if(this.WoodPelletSort == "asc") 
                {
                    this.WoodPelletSort = "desc";
                    this.woodPelletList = this.woodPelletList.sort((a,b) => {
                        return a.id - b.id
                    })
                } 
                else 
                {
                    this.WoodPelletSort = "asc"
                    this.woodPelletList = this.woodPelletList.sort((a,b) => {
                        return b.id - a.id
                    })
                }
        },

        sortByBrand()
        {
            if(this.WoodPelletSort == "asc")
                {
                    this.WoodPelletSort = "desc";
                    this.woodPelletList = this.woodPelletList.sort((a,b) => {
                        let fa = a.brand.toLowerCase()
                        let fb = b.brand.toLowerCase()
                        if (fa < fb)
                        {
                            return -1
                        }
                        if (fa > fb)
                        {
                            return 1
                        }
                        return 0
                    })
                } 
                else 
                {
                    this.WoodPelletSort = "asc"
                    this.woodPelletList = this.woodPelletList.sort((a,b) => {
                        let fa = a.brand.toLowerCase()
                        let fb = b.brand.toLowerCase()
                        if (fa < fb)
                        {
                            return 1
                        }
                        if (fa > fb)
                        {
                            return -1
                        }
                        return 0
                    })
                }
        },

        sortByPrice()
        {
            if(this.WoodPelletSort == "asc") 
                {
                    this.WoodPelletSort = "desc";
                    this.woodPelletList = this.woodPelletList.sort((a,b) => {
                        return a.price - b.price
                    })
                } 
                else 
                {
                    this.WoodPelletSort = "asc"
                    this.woodPelletList = this.woodPelletList.sort((a,b) => {
                        return b.price - a.price
                    })
                }
        },

        sortByQuality()
        {
            if(this.WoodPelletSort == "asc") 
                {
                    this.WoodPelletSort = "desc";
                    this.woodPelletList = this.woodPelletList.sort((a,b) => {
                        return a.quality - b.quality
                    })
                } 
                else 
                {
                    this.WoodPelletSort = "asc"
                    this.woodPelletList = this.woodPelletList.sort((a,b) => {
                        return b.quality - a.quality
                    })
                }
        }

    },
    
}).mount("#app")