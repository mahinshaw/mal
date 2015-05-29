#####################

DEBUG =

TESTS =

SOURCES_BASE = readline.fs #types.fs reader.fs printer.fs
SOURCES_LISP = #env.fs core.fs stepA_mal.fs
SOURCES = $(SOURCES_BASE) $(SOURCES_LISP)

#####################

SRCS = step0_repl.fs #step1_read_print.fs step2_eval.fs \
       step3_env.fs step4_if_fn_do.fs step5_tco.fs step6_file.fs \
       step7_quote.fs step8_macros.fs step9_try.fs stepA_mal.fs

LIB_CS_SRCS = getline.cs
LIB_FS_SRCS = $(filter-out step%,$(filter %.fs,$(SOURCES)))

FLAGS = $(if $(strip $(DEBUG)),-debug:full,)

#####################

all: mal.exe $(patsubst %.fs,%.exe,$(SRCS))

mal.exe: $(patsubst %.fs,%.exe,$(word $(words $(SOURCES)),$(SOURCES)))
	cp $< $@

mal_cs.dll: $(LIB_CS_SRCS)
	mcs $(FLAGS) -target:library $+ -out:$@

mal_fs.dll: mal_cs.dll $(LIB_FS_SRCS)
	fsharpc $(FLAGS) --target:library --reference:mal_cs.dll $(LIB_FS_SRCS) --out:$@

%.exe: %.fs mal_fs.dll
	fsharpc $(FLAGS) --reference:mal_fs.dll --reference:mal_cs.dll $<

clean:
	rm -f *.dll *.exe *.mdb

.PHONY: stats tests $(TESTS)

stats: $(SOURCES)
	@wc $^
stats-lisp: $(SOURCES_LISP)
	@wc $^

tests: $(TESTS)

$(TESTS):
	@echo "Running $@"; \
	./$@ || exit 1; \
